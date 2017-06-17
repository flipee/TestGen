using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestGen
{
    public partial class FormGerarAvaliacao : Form
    {
        private ColControlComplexidade colControlComplexidade = new ColControlComplexidade();
        private ColControlTipoQuestao colControlTipoQuestao = new ColControlTipoQuestao();
        private GeracaoAvaliacao geracaoAvaliacao = null;
        private bool inLoad;

        private int idDisciplina = 0;

        public event EventHandler<Avaliacao> eventRetorno;
        public void SetEventRetorno(EventHandler<Avaliacao> ev)
        {
            eventRetorno = ev;
        }

        public void SetParameters(int idDisciplina)
        {
            this.idDisciplina = idDisciplina;
        }

        public FormGerarAvaliacao()
        {
            InitializeComponent();
        }

        private void FormGerarAvaliacao_Load(object sender, EventArgs e)
        {
            numQtdQuestoes.Minimum = 5;
            numQtdQuestoes.Maximum = 100;

            numTempoPrevistoAvaliacao.Minimum = 0;
            numTempoPrevistoAvaliacao.Maximum = 21600;

            numTempoMaxProc.Minimum = 10;
            numTempoMaxProc.Maximum = 600;

            numQtdMaxGeracoes.Minimum = 1000;
            numQtdMaxGeracoes.Maximum = 4000000M;
            numQtdMaxGeracoes.ThousandsSeparator = true;

            numPercMinAceitavel.DecimalPlaces = 8;
            numPercMinAceitavel.Minimum = 95;
            numPercMinAceitavel.Maximum = 100;

            numProbabilidadeReproducao.DecimalPlaces = 2;
            numProbabilidadeReproducao.Minimum = 0.01M;
            numProbabilidadeReproducao.Maximum = 100;

            numProbabilidadeMutacao.DecimalPlaces = 2;
            numProbabilidadeMutacao.Minimum = 0.01M;
            numProbabilidadeMutacao.Maximum = 100;

            ViewControl.CarregarComboSeletorGA(cboSeletorGA);
            ViewControl.CarregarComboTipoAvaliacao(cboTipoAvaliacao);

            ConfiguracaoDefault();

            EnableControls();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGerarAvaliacao_Activated(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Tag = true;

                if (!CarregarDados())
                    this.Close();
            }
        }

        private bool CarregarDados()
        {
            bool ret = CarregarCombos();

            inLoad = true;

            if (!ret)
            {
                Mensagem.ShowAlerta(this,"Não foi possível carregar Disciplinas!");
            }

            inLoad = false;

            return ret;
        }

        private bool CarregarCombos()
        {
            bool ret = ViewControl.CarregarComboAtivo<Disciplina>(cboDisciplina);

            if (ret && idDisciplina != 0)
                cboDisciplina.SelectedValue = idDisciplina;

            return ret;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            bool ret = false;

            if (ValidarParametrizacao())
            {
                if (GravarParametrizacao())
                    ret=GerarAvaliacao();

                if (ret)
                    this.Close();
            }
        }

        private bool ValidarParametrizacao()
        {
            bool ret = true;
            /*
            if (ret)
            {
                ret = colControlComplexidade.HasConfiguratedRules > 0;

                if (!ret)
                    Mensagem.ShowAlerta(this,"Não existem regras definidas na configuração de complexidades!");
            }
            */
            if (ret)
            {
                ret = colControlComplexidade.IsAllValid;

                if (!ret)
                {
                    int index = colControlComplexidade.FirstInvalid;

                    Mensagem.ShowAlerta(this,"Regra " + (index + 1).ToString() + " da configuração de complexidades está inconsistênte ou incompleta!");
                }
            }
            /*
            if (ret)
            {
                ret = colControlTipoQuestao.HasConfiguratedRules > 0;

                if (!ret)
                    Mensagem.ShowAlerta(this,"Não existem regras definidas na configuração de tipos de questões!");
            }
            */
            if (ret)
            {
                ret = colControlTipoQuestao.IsAllValid;

                if (!ret)
                {
                    int index = colControlTipoQuestao.FirstInvalid;

                    Mensagem.ShowAlerta(this,"Tipo de questão [" + colControlTipoQuestao[index].TipoQuestao.ToString() + "] da configuração de tipos de questão está inconsistênte!");
                }
            }

            if (ret && colControlTipoQuestao.HasConfiguratedRules > 0)
            {
                ConfigTipoQuestao[] list = colControlTipoQuestao.GetValidConfigTipoQuestao();

                int qtdTotal = 0;

                foreach(ConfigTipoQuestao conf in list)
                {
                    qtdTotal += conf.Quantidade;
                }

                ret = qtdTotal <= numQtdQuestoes.Value;

                if (!ret)
                    Mensagem.ShowAlerta(this,"A soma das quantidades selecionadas na configuração de tipos de questão é maior que a quantidade de questões para a avaliação!");

                if (ret)
                {
                    ret=list.Length<4 || (list.Length==4 && qtdTotal == numQtdQuestoes.Value);

                    if (!ret)
                        Mensagem.ShowAlerta(this,"A configuração de tipos de questão não permite solução!");
                }
            }

            if (ret)
            {
                ret = !cboTipoAvaliacao.Text.Trim().Equals("");

                if (!ret)
                    Mensagem.ShowAlerta(this,"Tipo de Avaliação não foi selecionado!");
            }

            return ret;
        }

        private bool GravarParametrizacao()
        {
            bool ret = true;
            int idDisciplina = ViewControl.GetIdItemCombo(cboDisciplina);

            if (geracaoAvaliacao == null)
            {
                geracaoAvaliacao = new GeracaoAvaliacao();
                geracaoAvaliacao.IdDisciplina = idDisciplina;
            }

            geracaoAvaliacao.QtdQuestoesAvaliacao = (int)numQtdQuestoes.Value;
            geracaoAvaliacao.TempoPrevistoResposta = (int)numTempoPrevistoAvaliacao.Value;
            geracaoAvaliacao.IgnorarTempoMinReutilizacao = chkIgnorarTempoMinReutilizacao.Checked;

            geracaoAvaliacao.TempoMaximoProc = (int)numTempoMaxProc.Value;
            geracaoAvaliacao.QtdMaxGeracoes = (int)numQtdMaxGeracoes.Value;
            geracaoAvaliacao.PercMinAceitavel = (double)numPercMinAceitavel.Value;
            geracaoAvaliacao.ProbabilidadeReproducao = (double)numProbabilidadeReproducao.Value;
            geracaoAvaliacao.ProbabilidadeMutacao = (double)numProbabilidadeMutacao.Value;
            geracaoAvaliacao.Seletor = (SeletorGA)cboSeletorGA.SelectedValue;
            geracaoAvaliacao.HabilitaElitismo = chkHabilitaElitismo.Checked;

            geracaoAvaliacao.ConfigComplexidades = colControlComplexidade.GetConfigComplexidade();
            geracaoAvaliacao.ConfigTipoQuestoes = colControlTipoQuestao.GetConfigTipoQuestoes();

            List<GeracaoAvaliacao> list = DBControl.Table<GeracaoAvaliacao>.Pesquisar(x => x.IdDisciplina == idDisciplina);

            bool gravar = true;

            if (list != null && list.Count > 0)
            {
                gravar = !geracaoAvaliacao.ConfigEquals(list[0]);
            }

            if (gravar)
            {
                int id = DBControl.Table<GeracaoAvaliacao>.AutoIncluir(geracaoAvaliacao);

                ret = id != 0;

                if (ret)
                {
                    geracaoAvaliacao.Id = id;
                }
            }

            return ret;
        }

        private bool GerarAvaliacao()
        {
            bool ret = false;

            ConfigComplexidade[] complexRules = colControlComplexidade.GetValidConfigComplexidade();

            ConfigTipoQuestao[] tipoQuestaoRules = colControlTipoQuestao.GetValidConfigTipoQuestao();

            int idDisciplina = (int)cboDisciplina.SelectedValue;

            FormExecutaGeracaoAvaliacao formExecutaGeracaoAvaliacao = new FormExecutaGeracaoAvaliacao();

            string tipoAvaliacao = cboTipoAvaliacao.Text;

            ParametersGeneticAlgorithm parametersGA = new ParametersGeneticAlgorithm();

            parametersGA.QtdNaoRepetirAvaliacao = DBControl.Instituicao.QtdNaoRepetirAvaliacao;
            parametersGA.IdDisciplina = idDisciplina;
            parametersGA.QtdQuestoes = (int)numQtdQuestoes.Value;
            parametersGA.TempoPrevistoAvaliacao = (int)numTempoPrevistoAvaliacao.Value;
            parametersGA.IgnorarTempoMinReutilizacao = chkIgnorarTempoMinReutilizacao.Checked;
            parametersGA.ComplexRules = complexRules;
            parametersGA.TipoQuestaoRules = tipoQuestaoRules;
            parametersGA.MaxDuration = (int)numTempoMaxProc.Value;
            parametersGA.MaxGenerations = (int)numQtdMaxGeracoes.Value;
            parametersGA.MinFitnessGoal = (double)numPercMinAceitavel.Value;
            parametersGA.ProbabilidadeReproducao = (double)numProbabilidadeReproducao.Value;
            parametersGA.ProbabilidadeMutacao = (double)numProbabilidadeMutacao.Value;
            parametersGA.Seletor = (SeletorGA)cboSeletorGA.SelectedValue;
            parametersGA.HabilitaElitismo = chkHabilitaElitismo.Checked;

            formExecutaGeracaoAvaliacao.SetParameters(tipoAvaliacao,parametersGA);

            Avaliacao avaliacao = null;

            formExecutaGeracaoAvaliacao.SetEventRetorno(new EventHandler<Avaliacao>(delegate (Object o, Avaliacao a)
            {
                avaliacao = a;

                ret = avaliacao != null;
            }));

            formExecutaGeracaoAvaliacao.ShowDialog(this);

            if (ret && eventRetorno != null)
            {
                eventRetorno(this, avaliacao);
            }
            return ret;
        }

        private void numQtdQuestoes_ValueChanged(object sender, EventArgs e)
        {
            colControlComplexidade.QtdMaxima = (int)numQtdQuestoes.Value;
            colControlTipoQuestao.QtdMaxima = (int)numQtdQuestoes.Value;
        }

        private void cboDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableControls();

            if (cboDisciplina.SelectedIndex >= 0 && (int)cboDisciplina.SelectedValue > 0)
                LerConfiguracaoGeracaoAvaliacao((int)cboDisciplina.SelectedValue);
        }

        private void chkIgnorarTempoMinReutilizacao_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void EnableControls()
        {
            cboDisciplina.Enabled = idDisciplina == 0;

            bool enabled = cboDisciplina.SelectedIndex >= 0 && !cboDisciplina.Text.Equals("");

            numQtdQuestoes.Enabled = enabled;
            numTempoPrevistoAvaliacao.Enabled = enabled;
            chkIgnorarTempoMinReutilizacao.Enabled = enabled;

            numTempoMaxProc.Enabled = enabled;
            numQtdMaxGeracoes.Enabled = enabled;
            numPercMinAceitavel.Enabled = enabled;
            numProbabilidadeReproducao.Enabled = enabled;
            numProbabilidadeMutacao.Enabled = enabled;
            cboSeletorGA.Enabled = enabled;
            chkHabilitaElitismo.Enabled = enabled;
            cboTipoAvaliacao.Enabled = enabled;

            colControlComplexidade.EnableAllControls(enabled);
            colControlTipoQuestao.EnableAllControls(enabled);

            btnGerar.Enabled = enabled;
        }

        private bool LerConfiguracaoGeracaoAvaliacao(int idDisciplina)
        {
            bool ret = false;

            List<GeracaoAvaliacao> list = DBControl.Table<GeracaoAvaliacao>.Pesquisar(x => x.IdDisciplina == idDisciplina);

            if (list!=null && list.Count > 0)
            {
                geracaoAvaliacao = list[0];

                numQtdQuestoes.Value = geracaoAvaliacao.QtdQuestoesAvaliacao;
                numTempoPrevistoAvaliacao.Value = geracaoAvaliacao.TempoPrevistoResposta;
                chkIgnorarTempoMinReutilizacao.Checked = geracaoAvaliacao.IgnorarTempoMinReutilizacao;

                if ((decimal)geracaoAvaliacao.TempoMaximoProc < numTempoMaxProc.Minimum)
                    numTempoMaxProc.Value = numTempoMaxProc.Minimum;
                else if ((decimal)geracaoAvaliacao.TempoMaximoProc > numTempoMaxProc.Maximum)
                    numTempoMaxProc.Value = numTempoMaxProc.Maximum;
                else
                    numTempoMaxProc.Value = (decimal)geracaoAvaliacao.TempoMaximoProc;

                if ((decimal)geracaoAvaliacao.QtdMaxGeracoes < numQtdMaxGeracoes.Minimum)
                    numQtdMaxGeracoes.Value = numQtdMaxGeracoes.Minimum;
                else if ((decimal)geracaoAvaliacao.QtdMaxGeracoes > numQtdMaxGeracoes.Maximum)
                    numQtdMaxGeracoes.Value = numQtdMaxGeracoes.Maximum;
                else
                    numQtdMaxGeracoes.Value = (decimal)geracaoAvaliacao.QtdMaxGeracoes;

                if ((decimal)geracaoAvaliacao.PercMinAceitavel < numPercMinAceitavel.Minimum)
                    numPercMinAceitavel.Value = numPercMinAceitavel.Minimum;
                else if ((decimal)geracaoAvaliacao.PercMinAceitavel > numPercMinAceitavel.Maximum)
                    numPercMinAceitavel.Value = numPercMinAceitavel.Maximum;
                else
                    numPercMinAceitavel.Value = (decimal)geracaoAvaliacao.PercMinAceitavel;

                if ((decimal)geracaoAvaliacao.ProbabilidadeReproducao < numProbabilidadeReproducao.Minimum)
                    numProbabilidadeReproducao.Value = numProbabilidadeReproducao.Minimum;
                else if ((decimal)geracaoAvaliacao.ProbabilidadeReproducao > numProbabilidadeReproducao.Maximum)
                    numProbabilidadeReproducao.Value = numProbabilidadeReproducao.Maximum;
                else
                    numProbabilidadeReproducao.Value = (decimal)geracaoAvaliacao.ProbabilidadeReproducao;

                if ((decimal)geracaoAvaliacao.ProbabilidadeMutacao < numProbabilidadeMutacao.Minimum)
                    numProbabilidadeMutacao.Value = numProbabilidadeMutacao.Minimum;
                else if ((decimal)geracaoAvaliacao.ProbabilidadeMutacao > numProbabilidadeMutacao.Maximum)
                    numProbabilidadeMutacao.Value = numProbabilidadeMutacao.Maximum;
                else
                    numProbabilidadeMutacao.Value = (decimal)geracaoAvaliacao.ProbabilidadeMutacao;

                cboSeletorGA.SelectedValue = (int)geracaoAvaliacao.Seletor;

                chkHabilitaElitismo.Checked = geracaoAvaliacao.HabilitaElitismo;

                colControlComplexidade.QtdMaxima = geracaoAvaliacao.QtdQuestoesAvaliacao;

                colControlComplexidade.InitFromConfigComplexidades(geracaoAvaliacao.ConfigComplexidades);
                colControlTipoQuestao.InitFromConfigTipoQuestoes(geracaoAvaliacao.ConfigTipoQuestoes);

                ret = true;
            }
            else
            {
                geracaoAvaliacao = null;
                ConfiguracaoDefault();
            }

            return ret;
        }

        private void ConfiguracaoDefault()
        {
            numQtdQuestoes.Value = DBControl.Instituicao.QtdQuestoesAvaliacao;

            colControlComplexidade.QtdMaxima = (int)numQtdQuestoes.Value;

            numTempoPrevistoAvaliacao.Value = 0;

            numProbabilidadeReproducao.Value = 30;
            numProbabilidadeMutacao.Value = 1.5M;

            numTempoMaxProc.Value = 30;
            numQtdMaxGeracoes.Value = 2000000;

            numPercMinAceitavel.Value = 99.9999995M;

            chkHabilitaElitismo.Checked = true;

            cboSeletorGA.SelectedIndex = 0;
            cboTipoAvaliacao.SelectedIndex = -1;

            chkIgnorarTempoMinReutilizacao.Checked = false;

            if (colControlComplexidade.Count==0)
            {
                colControlComplexidade.AddRule(numComplexIni1, numComplexFim1, numComplexQtd1);
                colControlComplexidade.AddRule(numComplexIni2, numComplexFim2, numComplexQtd2);
                colControlComplexidade.AddRule(numComplexIni3, numComplexFim3, numComplexQtd3);
                colControlComplexidade.AddRule(numComplexIni4, numComplexFim4, numComplexQtd4);
                colControlComplexidade.AddRule(numComplexIni5, numComplexFim5, numComplexQtd5);
                colControlComplexidade.AddRule(numComplexIni6, numComplexFim6, numComplexQtd6);
                colControlComplexidade.AddRule(numComplexIni7, numComplexFim7, numComplexQtd7);
                colControlComplexidade.AddRule(numComplexIni8, numComplexFim8, numComplexQtd8);
                colControlComplexidade.AddRule(numComplexIni9, numComplexFim9, numComplexQtd9);
                colControlComplexidade.AddRule(numComplexIni10, numComplexFim10, numComplexQtd10);
            }

            if (colControlTipoQuestao.Count==0)
            {
                colControlTipoQuestao.AddRule(TipoDeQuestao.Discursiva, chkQuestaoDiscursiva, numQtdQuestaoDiscursiva);
                colControlTipoQuestao.AddRule(TipoDeQuestao.EscolhaSimples, chkQuestaoEscolhaSimples, numQtdQuestaoEscolhaSimples);
                colControlTipoQuestao.AddRule(TipoDeQuestao.MultiplaEscolha, chkQuestaoMultiplaEscolha, numQtdQuestaoMultiplaEscolha);
                colControlTipoQuestao.AddRule(TipoDeQuestao.ListaDeAssociacao, chkQuestaoListaAssociacao, numQtdQuestaoListaAssociacao);
            }

            colControlComplexidade.ConfiguracaoDefault();
            colControlTipoQuestao.ConfiguracaoDefault();
        }

    }
}
