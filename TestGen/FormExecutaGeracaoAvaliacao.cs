using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGen
{
    public partial class FormExecutaGeracaoAvaliacao : Form
    {
        ParametersGeneticAlgorithm parametersGA = null;
        string tipoAvaliacao = "";
        Disciplina disciplina = null;
        DateTime dtGeracao;
        DateTime startTime;

        List<int> questoes = null;

        Avaliacao avaliacao = null;

        public event EventHandler<Avaliacao> eventRetorno;

        public FormExecutaGeracaoAvaliacao()
        {
            InitializeComponent();
        }
        public void SetParameters(string tipoAvaliacao,ParametersGeneticAlgorithm parametersGA)
        {
            this.tipoAvaliacao = tipoAvaliacao;
            this.parametersGA = parametersGA;
            this.dtGeracao = DateTime.Today;
        }

        public void SetEventRetorno(EventHandler<Avaliacao> ev)
        {
            eventRetorno = ev;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (GravarAvaliacao())
            {
                if (eventRetorno != null)
                    eventRetorno(this, avaliacao);

                this.Close();
            }
        }

        private void GerarListaDeQuestoes()
        {
            parametersGA.Avaliacoes = DBControl.Table<Avaliacao>.Pesquisar();
            parametersGA.QuestoesAvaliacao = DBControl.Table<AvaliacaoQuestao>.Pesquisar();

            parametersGA.AvaliacoesAnteriores = AvaliacoesAnteriores(parametersGA.QuestoesAvaliacao);

            parametersGA.QuestoesAvaliacao.Sort((x, y) => x.DtGeracao.CompareTo(y.DtGeracao));

            List<Questao> listQuestao = DBControl.Table<Questao>.Pesquisar(x => x.IdDisciplina == parametersGA.IdDisciplina && x.Ativo);

            foreach (var questao in listQuestao)
            {
                DateTime dtUtilizacao = new DateTime(1, 1, 1);

                AvaliacaoQuestao aq = parametersGA.QuestoesAvaliacao.FindLast(x => x.IdQuestao == questao.Id);

                if (aq != null)
                {
                    Avaliacao av = parametersGA.Avaliacoes.FindLast(x => x.Id == aq.IdAvaliacao);

                    if (av != null)
                        dtUtilizacao = av.DtGeracao;
                }

                if (parametersGA.IgnorarTempoMinReutilizacao || (DateTime.Today - dtUtilizacao).TotalDays > questao.TempoMinimoReutilizacao)
                    parametersGA.Questoes.Add(questao);
            }
        }

        private void FormExecutaGeracaoAvaliacao_Activated(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Tag = true;

                btnGravar.Enabled = false;
                btnFechar.Enabled = false;

                if (CarregarDados() && ValidarParametrizacao())
                    ProcessarGeracao();
                else
                {
                    btnFechar.Enabled = true;

                    this.Close();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            AtualizaTempoProcessamento();
        }

        private async void ProcessarGeracao()
        {
            bool ret = false;

            Cursor.Current = Cursors.WaitCursor;

            ProcessGeneticAlgorithm pga = new ProcessGeneticAlgorithm(parametersGA);

            //pga.OnGANewGeneration += OnGANewGeneration;
            pga.OnGANewBestFitness += OnGANewBestFitness;

            btnParar.Visible = true;

            this.btnParar.Click += new System.EventHandler(delegate (object sender, EventArgs e)
            {
                pga.StopProcess();
            });

            startTime = DateTime.Now;

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);

            await Task.Run(() =>
            {
                GerarListaDeQuestoes();

                ret = parametersGA.Questoes.Count >= parametersGA.QtdQuestoes;
            });

            txtQtdQuestoesDisponiveis.Text = parametersGA.Questoes.Count.ToString("#,##0", CultureInfo.CurrentCulture);

            if (!ret)
                ShowAlerta("Não há questões disponíveis para atender a quantidade de questões solicitada para a avaliação!");

            if (ret)
            {
                timer.Start();

                await Task.Run(() =>
                {
                    ret = pga.Execute();

                });

                timer.Stop();

                AtualizaTempoProcessamento();
            }

            btnParar.Visible = false;

            if (ret)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(@"{\rtf1\ansi");
                sb.Append(@"\ansicpg1252\deff0\deflang1033");
                sb.Append(@"{\fonttbl{\f0\fnil\fcharset0 Courier New;}}");
                sb.Append(@"{\colortbl;\red255\green0\blue0;\red0\green255\blue0;\red0\green0\blue255; }");

                sb.Append("Quantidade de gerações: ").Append(@"\b ").Append(pga.GenerationCount.ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ").Append(@" \line ");
                sb.Append("Tempo de Processamento (Segs.): ").Append(@"\b ").Append(pga.ElapTimeSeconds.ToString()).Append(@"\b0 ").Append(@" \line ");
                sb.Append("Tipo de Finalização: ").Append(@"\b ").Append(pga.ExitCondiction.ToString()).Append(@"\b0 ").Append(@" \line ");

                sb.Append("Fitness: ").Append(@"\b ").Append(pga.BestGenome.Fitness.ToString()).Append(@"\b0").Append(@" \line ");
                sb.Append("Geração: ").Append(@"\b ").Append(pga.BestGenome.Generation.ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ").Append(@" \line ");

                //sb.Append("Hashcode: ").Append(pga.BestGenome.GetHashCode().ToString()).Append(@" \line ");

                sb.Append("Quantidade de Questões: ").Append(@"\b ").Append(pga.BestGenome.QtdTotal().ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ");
                if (pga.BestGenome.QtdTotal() != parametersGA.QtdQuestoes)
                {
                    sb.Append(@"\b ").Append(@"\cf1 ").Append(" <= Incorreto (Solicitado ").Append(parametersGA.QtdQuestoes.ToString("#,##0", CultureInfo.CurrentCulture)).Append(")").Append(@"\b0 ").Append(@"\cf0");
                    ret = false;
                }
                sb.Append(@" \line ");

                sb.Append("Status:\t").Append(@"\b ");
                if (ret)
                    sb.Append(@"\b ").Append("Gravação da Avaliação Permitida").Append(@"\b0 ").Append(@" \line ");
                else
                    sb.Append(@"\b ").Append(@"\cf1").Append("Impossível Gravar Avaliação").Append(@"\b0 ").Append(@"\cf0").Append(@" \line ");

                sb.Append("Tempo Total das Questões: ").Append(@"\b ").Append(pga.BestGenome.TempoTotal().ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ");
                if (parametersGA.TempoPrevistoAvaliacao!=0 && pga.BestGenome.TempoTotal() != parametersGA.TempoPrevistoAvaliacao)
                    sb.Append(@"\b ").Append(" <= Incorreto (Solicitado ").Append(parametersGA.TempoPrevistoAvaliacao.ToString("#,##0", CultureInfo.CurrentCulture)).Append(")").Append(@"\b0 ");
                sb.Append(@" \line ");

                sb.Append(@" \line ");

                List<ConfigTipoQuestao> tipoQuestaoRules = new List<ConfigTipoQuestao>(parametersGA.TipoQuestaoRules);
                ConfigTipoQuestao cqr;

                sb.Append("Quantidades por Tipo:").Append(@" \line ");

                sb.Append("\t").Append(TipoDeQuestao.Discursiva.ToString()).Append(":\t\t").Append(@"\b ").Append(pga.BestGenome.TipoTotal((int)TipoDeQuestao.Discursiva, (int)TipoDeQuestao.Discursiva).ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ");
                cqr = tipoQuestaoRules.Find(x => x.TipoQuestao == TipoDeQuestao.Discursiva);
                if (cqr != null && pga.BestGenome.TipoTotal((int)TipoDeQuestao.Discursiva, (int)TipoDeQuestao.Discursiva) != cqr.Quantidade)
                    sb.Append(@"\b ").Append(" <= Incorreto (Solicitado ").Append(cqr.Quantidade.ToString("#,##0", CultureInfo.CurrentCulture)).Append(")").Append(@"\b0 ");
                sb.Append(@" \line ");

                sb.Append("\t").Append(TipoDeQuestao.EscolhaSimples.ToString()).Append(":\t").Append(@"\b ").Append(pga.BestGenome.TipoTotal((int)TipoDeQuestao.EscolhaSimples, (int)TipoDeQuestao.EscolhaSimples).ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ");
                cqr = tipoQuestaoRules.Find(x => x.TipoQuestao == TipoDeQuestao.EscolhaSimples);
                if (cqr != null && pga.BestGenome.TipoTotal((int)TipoDeQuestao.EscolhaSimples, (int)TipoDeQuestao.EscolhaSimples) != cqr.Quantidade)
                    sb.Append(@"\b ").Append(" <= Incorreto (Solicitado ").Append(cqr.Quantidade.ToString("#,##0", CultureInfo.CurrentCulture)).Append(")").Append(@"\b0 ");
                sb.Append(@" \line ");

                sb.Append("\t").Append(TipoDeQuestao.MultiplaEscolha.ToString()).Append(":\t").Append(@"\b ").Append(pga.BestGenome.TipoTotal((int)TipoDeQuestao.MultiplaEscolha, (int)TipoDeQuestao.MultiplaEscolha).ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ");
                cqr = tipoQuestaoRules.Find(x => x.TipoQuestao == TipoDeQuestao.MultiplaEscolha);
                if (cqr != null && pga.BestGenome.TipoTotal((int)TipoDeQuestao.MultiplaEscolha, (int)TipoDeQuestao.MultiplaEscolha) != cqr.Quantidade)
                    sb.Append(@"\b ").Append(" <= Incorreto (Solicitado ").Append(cqr.Quantidade.ToString("#,##0", CultureInfo.CurrentCulture)).Append(")").Append(@"\b0 ");
                sb.Append(@" \line ");

                sb.Append("\t").Append(TipoDeQuestao.ListaDeAssociacao.ToString()).Append(":\t").Append(@"\b ").Append(pga.BestGenome.TipoTotal((int)TipoDeQuestao.ListaDeAssociacao, (int)TipoDeQuestao.ListaDeAssociacao).ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ");
                cqr = tipoQuestaoRules.Find(x => x.TipoQuestao == TipoDeQuestao.ListaDeAssociacao);
                if (cqr != null && pga.BestGenome.TipoTotal((int)TipoDeQuestao.ListaDeAssociacao, (int)TipoDeQuestao.ListaDeAssociacao) != cqr.Quantidade)
                    sb.Append(@"\b ").Append(" <= Incorreto (Solicitado ").Append(cqr.Quantidade.ToString("#,##0", CultureInfo.CurrentCulture)).Append(")").Append(@"\b0 ");
                sb.Append(@" \line ");

                sb.Append(@" \line ");

                if (parametersGA.ComplexRules.Length > 0)
                {
                    sb.Append("Quantidades por regra de Complexidade:").Append(@" \line ");
                    foreach (ConfigComplexidade c in parametersGA.ComplexRules)
                    {
                        sb.Append("\tComplexidade ").Append(c.ComplexIni.ToString()).Append(" a ").Append(c.ComplexFim.ToString()).Append(":\t").Append(@"\b ").Append(pga.BestGenome.ComplexTotal(c.ComplexIni, c.ComplexFim).ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ");

                        if (pga.BestGenome.ComplexTotal(c.ComplexIni, c.ComplexFim) != c.Quantidade)
                            sb.Append(@"\b ").Append(" <= Incorreto (Solicitado ").Append(c.Quantidade.ToString("#,##0", CultureInfo.CurrentCulture)).Append(")").Append(@"\b0 ");

                        sb.Append(@" \line ");
                    }
                    sb.Append(@" \line ");
                }

                sb.Append("Quantidades por Complexidade:").Append(@" \line "); 
                for (int i = 1; i <= 10; i++)
                {
                    sb.Append("\tComplexidade ").Append(i.ToString()).Append(":\t").Append(@"\b ").Append(pga.BestGenome.ComplexTotal(i, i).ToString("#,##0", CultureInfo.CurrentCulture)).Append(@"\b0 ").Append(@" \line ");
                }

                sb.Append(@" \line ");

                sb.Append("IDs das Questões:").Append(@" \line ");
                sb.Append(pga.BestGenome.ToString().Replace("|", ", ")).Append(@" \line ");

                sb.Append(" }");

                rtxResultado.Rtf = sb.ToString();
            }
            else
            {
                rtxResultado.Text = "Houve erro na geração da Avaliação.";
            }
            

            if (pga.BestGenome != null)
                questoes = new List<int>(pga.BestGenome.IdsQuestoes());
            else
                questoes= new List<int>();

            btnFechar.Enabled = true;
            btnGravar.Enabled = ret;

            Cursor.Current = Cursors.Default;
        }

        private void FormExecutaGeracaoAvaliacao_Load(object sender, EventArgs e)
        {
            txtGeracao.ReadOnly = true;
            txtFitness.ReadOnly = true;
            txtTempo.ReadOnly = true;
            txtTempoProcessamento.ReadOnly = true;
            rtxResultado.ReadOnly = true;
            txtQtdQuestoesDisponiveis.ReadOnly = true;

            btnParar.Visible = false;
        }

        private void FormExecutaGeracaoAvaliacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !btnFechar.Enabled;
        }

        private bool GravarAvaliacao()
        {
            bool ret = false;

            DBControl.BeginTrans();

            try
            {
                avaliacao = new Avaliacao();

                string codigo = GetCodigoAvaliacao();

                string strSeq = "";

                List<Avaliacao> avaliacoes = DBControl.Table<Avaliacao>.Pesquisar(x => x.Codigo.StartsWith(codigo));

                if (avaliacoes != null && avaliacoes.Count>0)
                {
                    strSeq = avaliacoes[avaliacoes.Count - 1].Codigo.Substring(codigo.Length);
                }

                int seq = 1;

                if (!strSeq.Equals(""))
                {
                    seq = int.Parse(strSeq);
                    seq++;
                }

                codigo = codigo + seq.ToString("000");

                StringBuilder sb = new StringBuilder();

                sb.Append("Avaliação ");
                sb.Append(tipoAvaliacao);
                sb.Append(" ");
                sb.Append(disciplina.Nome);
                sb.Append(" sequência ");
                sb.Append(seq.ToString("000"));

                avaliacao.Codigo = codigo;
                avaliacao.Descricao = sb.ToString();
                avaliacao.DtGeracao = dtGeracao;
                avaliacao.IdDisciplina = parametersGA.IdDisciplina;
                avaliacao.QtdQuestoes = parametersGA.QtdQuestoes;

                int idAvaliacao = DBControl.Table<Avaliacao>.Incluir(avaliacao);

                ret = idAvaliacao > 0;

                if (ret)
                {
                    AvaliacaoQuestao aq;
                    int id;

                    foreach (int idQuestao in questoes)
                    {
                        aq = new AvaliacaoQuestao();

                        aq.IdAvaliacao = idAvaliacao;
                        aq.DtGeracao = dtGeracao;
                        aq.IdQuestao = idQuestao;

                        id = DBControl.Table<AvaliacaoQuestao>.Incluir(aq);

                        ret = id > 0;

                        if (!ret)
                            break;
                    }
                }

                if (ret)
                    DBControl.Commit();
                else
                    DBControl.Rollback();
            }
            catch (Exception ex)
            {
                Mensagem.ShowErro("Erro na inclusão da Avaliação!", ex);
                DBControl.Rollback();
            }

            return ret;
        }

        private List<AvaliacaoAnterior> AvaliacoesAnteriores(List<AvaliacaoQuestao> questoesAvaliacao)
        {
            DateTime dataAtual = DateTime.Today;

            List<AvaliacaoAnterior> lista = new List<AvaliacaoAnterior>();
            List<AvaliacaoAnterior> ret = new List<AvaliacaoAnterior>();

            AvaliacaoAnterior avaliacaoAnterior;

            foreach (AvaliacaoQuestao aq in questoesAvaliacao)
            {
                avaliacaoAnterior = lista.Find(x => x.IdAvaliacao == aq.IdAvaliacao);

                if (avaliacaoAnterior == null)
                {
                    avaliacaoAnterior = new AvaliacaoAnterior();
                    avaliacaoAnterior.Questoes = new List<int>();
                    avaliacaoAnterior.IdAvaliacao = aq.IdAvaliacao;
                    avaliacaoAnterior.DtUtilizacao = aq.DtGeracao;

                    lista.Add(avaliacaoAnterior);
                }

                avaliacaoAnterior.Questoes.Add(aq.IdQuestao);
            }

            StringBuilder sb = new StringBuilder();

            foreach (AvaliacaoAnterior a in lista)
            {
                a.Questoes.Sort();

                if ((dataAtual - a.DtUtilizacao).Days <= parametersGA.QtdNaoRepetirAvaliacao)
                {
                    sb.Clear();

                    foreach (int value in a.Questoes)
                        sb.Append("|").Append(value.ToString());

                    a.Key = sb.ToString().Substring(2);
                    a.HashCode = a.GetHashCode();

                    avaliacaoAnterior = ret.Find(x => x.Key == a.Key);
                    if (avaliacaoAnterior != null && avaliacaoAnterior.DtUtilizacao < a.DtUtilizacao)
                    {
                        avaliacaoAnterior.IdAvaliacao = a.IdAvaliacao;
                        avaliacaoAnterior.DtUtilizacao = a.DtUtilizacao;
                    }
                    else
                        ret.Add(a);
                }
            }

            return ret;
        }

        /*
        public void OnGANewGeneration(ProcessGeneticAlgorithm sender, GenerationEventArgs args)
        {
            if (InvokeRequired)
            {
                Invoke((Action<ProcessGeneticAlgorithm, GenerationEventArgs>)OnGANewGeneration, sender, args);
            }
            else
            {
            }
        }
        */

        public void OnGANewBestFitness(ProcessGeneticAlgorithm sender,CustomGenomeEventArgs args)
        {
            if (InvokeRequired)
            {
                Invoke((Action<ProcessGeneticAlgorithm, CustomGenomeEventArgs>)OnGANewBestFitness, sender, args);
            }
            else
            {
                txtGeracao.Text = args.Genome.Generation.ToString("#,##0", CultureInfo.CurrentCulture);
                txtFitness.Text = args.Genome.Fitness.ToString();
                txtTempo.Text = args.Genome.TempoTotal().ToString("#,##0", CultureInfo.CurrentCulture);
            }
        }

        public void ShowAlerta(string mensagem)
        {
            if (InvokeRequired)
            {
                Invoke((Action<string>)ShowAlerta, mensagem);
            }
            else
                Mensagem.ShowAlerta(this,mensagem);
        }
        public DialogResult ShowPerguntaSimNao(string mensagem)
        {
            if (InvokeRequired)
            {
                return (DialogResult)Invoke(new Func<String, DialogResult>((x) => ShowPerguntaSimNao(x)));
            }
            else
                return Mensagem.ShowPerguntaSimNao(this,mensagem);
        }
        private String GetCodigoAvaliacao()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(disciplina.Codigo);
            sb.Append(tipoAvaliacao);
            sb.Append(dtGeracao.ToString("yyyyMMdd"));

            return sb.ToString();
        }

        private bool CarregarDados()
        {
            disciplina=DBControl.Table<Disciplina>.Ler(parametersGA.IdDisciplina);

            return (disciplina != null && disciplina.Id != 0);
        }

        private bool ValidarParametrizacao()
        {
            bool ret = true;

            string codigo = GetCodigoAvaliacao();

            List<Avaliacao> avaliacoes = DBControl.Table<Avaliacao>.Pesquisar(x => x.Codigo.StartsWith(codigo));

            ret = avaliacoes == null || avaliacoes.Count == 0;

            if (!ret)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("Já ");
                if (avaliacoes.Count > 1)
                {
                    sb.Append("existem ");
                    sb.Append(avaliacoes.Count.ToString());
                    sb.Append(" avaliações gravadas");
                }
                else
                    sb.Append("existe uma avaliação gravada");

                sb.Append(" para o tipo ");
                sb.Append(tipoAvaliacao);
                sb.Append(" com geração em ");
                sb.Append(dtGeracao.ToShortDateString());
                sb.Append("!\r\nGostaria de criar uma nova?");

                ret = ShowPerguntaSimNao(sb.ToString()) == DialogResult.Yes;
            }

            return ret;
        }

        private void AtualizaTempoProcessamento()
        {
            txtTempoProcessamento.Text = (DateTime.Now - startTime).TotalSeconds.ToString("#,##0.0");
        }
    }
}
