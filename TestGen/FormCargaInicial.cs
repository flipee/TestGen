using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGen
{
    public partial class FormCargaInicial : Form
    {
        private bool inLoad;

        public FormCargaInicial()
        {
            InitializeComponent();
        }

        private void FormCargaInicial_Load(object sender, EventArgs e)
        {
            pnlProgress.Visible = false;

            rdbGerarNovas.Checked = true;

            numQtdQuestoes.Minimum = 50;
            numQtdQuestoes.Maximum = 100000;
            numQtdQuestoes.Value = 10000;
            numQtdQuestoes.ThousandsSeparator = true;

            EnableControls(true);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (Mensagem.ShowPerguntaSimNao(this,"Confirma geração de carga inicial randômica das questões?") == DialogResult.Yes)
            {
                ExecutaCargaInicial();
            }
        }

        private void SetPrbMaximo(int maximo)
        {
            if (InvokeRequired)
            {
                Invoke((Action<int>)SetPrbMaximo, maximo);
                return;
            }
            else
                prbGeracaoQuestoes.Maximum = maximo;
        }
        private void SetPrbValue(int value)
        {
            if (InvokeRequired)
            {
                Invoke((Action<int>)SetPrbValue, value);
                return;
            }
            else
                prbGeracaoQuestoes.Value = value;
        }

        private void IncPrbValue(int value)
        {
            if (InvokeRequired)
            {
                Invoke((Action<int>)IncPrbValue, value);
                return;
            }
            else
                prbGeracaoQuestoes.Increment(value);
        }

        private void SetLblStatusText(string text)
        {
            if (InvokeRequired)
            {
                Invoke((Action<string>)SetLblStatusText, text);
                return;
            }
            else
            {
                lblStatus.Text = text;
                lblStatus.Refresh();
            }
        }

        private void EnableControls(bool enabled)
        {
            cboDisciplina.Enabled = enabled;

            numQtdQuestoes.Enabled = enabled && rdbGerarNovas.Checked;

            rdbGerarNovas.Enabled = enabled;
            rdbRemoverExistentes.Enabled = enabled;

            btnGravar.Enabled = enabled && (numQtdQuestoes.Value > 0 || !rdbGerarNovas.Enabled);
            btnFechar.Enabled = enabled;
        }

        private async void ExecutaCargaInicial()
        {

            bool ret = false;

            int idDisciplina = (int)cboDisciplina.SelectedValue;

            bool incluir = rdbGerarNovas.Checked;
            bool excluir = rdbGerarNovas.Checked || rdbRemoverExistentes.Checked;

            Cursor.Current = Cursors.WaitCursor;

            EnableControls(false);

            pnlProgress.Visible = true;

            await Task.Run(() =>
            {
                ret = true;

                if (excluir)
                {
                    SetPrbValue(0);
                    SetLblStatusText("Excluindo questões anteriores! Por favor espere...");

                    ret = ExcluirDadosAnteriores(idDisciplina);
                }

                if (ret && incluir)
                {
                    SetPrbValue(0);
                    SetLblStatusText("Incluindo novas questões! Por favor espere...");

                    ret = IncluirNovosDados(idDisciplina,(int)numQtdQuestoes.Value);
                }
            });

            pnlProgress.Visible = false;

            Cursor.Current = Cursors.Default;

            if (ret)
            {
                if (incluir)
                    Mensagem.ShowAlerta(this,"Novas questões geradas com sucesso!");
                else
                    Mensagem.ShowAlerta(this,"Questões removidas com sucesso!");

                btnFechar.Enabled = true;

                this.Close();
            }
            else
                EnableControls(true);
        }

        private bool ExcluirDadosAnteriores(int idDisciplina)
        {
            bool ret = true;

            List<AvaliacaoQuestao> listAQ = null;
            List<Avaliacao> listA = null;
            List<Questao> listQ = null;
            List<QuestaoItemAssociacao> listQIA = null;
            List<QuestaoUtilizacao> listQU = null;
            List<QuestaoItemEscolha> listQIE = null;

            if (idDisciplina == 0)
            {
                listAQ = DBControl.Table<AvaliacaoQuestao>.Pesquisar();
                listA = DBControl.Table<Avaliacao>.Pesquisar();
                listQ = DBControl.Table<Questao>.Pesquisar();
                listQIA = DBControl.Table<QuestaoItemAssociacao>.Pesquisar();
                listQU = DBControl.Table<QuestaoUtilizacao>.Pesquisar();
                listQIE = DBControl.Table<QuestaoItemEscolha>.Pesquisar();
            }
            else
            {
                listA = DBControl.Table<Avaliacao>.Pesquisar(x => x.IdDisciplina == idDisciplina);

                listAQ = DBControl.Table<AvaliacaoQuestao>.Pesquisar();
                listAQ.RemoveAll(x => listA.FindIndex(y => y.Id == x.IdAvaliacao)<0);

                listQ = DBControl.Table<Questao>.Pesquisar(x => x.IdDisciplina == idDisciplina);

                listQIA = DBControl.Table<QuestaoItemAssociacao>.Pesquisar();
                listQIA.RemoveAll(x => listQ.FindIndex(y => y.Id == x.IdQuestao) < 0);

                listQU = DBControl.Table<QuestaoUtilizacao>.Pesquisar();
                listQU.RemoveAll(x => listQ.FindIndex(y => y.Id == x.IdQuestao) < 0);

                listQIE = DBControl.Table<QuestaoItemEscolha>.Pesquisar();
                listQIE.RemoveAll(x => listQ.FindIndex(y => y.Id == x.IdQuestao) < 0);
            }

            SetPrbMaximo(listAQ.Count+listA.Count+listQIA.Count+listQU.Count+listQIE.Count+listQ.Count);
            SetPrbValue(0);

            foreach (AvaliacaoQuestao aq in listAQ)
            {
                ret = DBControl.Table<AvaliacaoQuestao>.Excluir(aq);

                if (!ret)
                    break;

                IncPrbValue(1);
            }

            if (ret)
            {
                foreach (Avaliacao a in listA)
                {
                    ret = DBControl.Table<Avaliacao>.Excluir(a);

                    if (!ret)
                        break;

                    IncPrbValue(1);
                }
            }

            if (ret)
            {
                foreach (QuestaoUtilizacao qu in listQU)
                {
                    ret = DBControl.Table<QuestaoUtilizacao>.Excluir(qu);

                    if (!ret)
                        break;

                    IncPrbValue(1);
                }
            }

            if (ret)
            {
                foreach (QuestaoItemAssociacao qia in listQIA)
                {
                    ret = DBControl.Table<QuestaoItemAssociacao>.Excluir(qia);

                    if (!ret)
                        break;

                    IncPrbValue(1);
                }

                if (ret)
                {
                    foreach (QuestaoItemEscolha qie in listQIE)
                    {
                        ret = DBControl.Table<QuestaoItemEscolha>.Excluir(qie);

                        if (!ret)
                            break;

                        IncPrbValue(1);
                    }
                }

                if (ret)
                {
                    foreach (Questao q in listQ)
                    {
                        ret = DBControl.Table<Questao>.Excluir(q);

                        if (!ret)
                            break;

                        IncPrbValue(1);
                    }
                }
            }

            return ret;
        }

        private bool IncluirNovosDados(int idDisciplina,int qtdQuestoes)
        {
            bool ret;

            SetPrbMaximo(qtdQuestoes);
            SetPrbValue(0);

            List<Disciplina> listD = null;

            if (idDisciplina == 0)
            {
                listD = DBControl.Table<Disciplina>.Pesquisar(x => x.Ativo);
            }
            else
            {
                listD = DBControl.Table<Disciplina>.Pesquisar(x => x.Id==idDisciplina);
            }

            ret = (listD != null);

            if (ret)
            {
                Random random = new Random();

                Questao q;
                QuestaoItemEscolha qi;
                QuestaoItemAssociacao qa;


                int idQuestao;

                for (int i = 1; i <= qtdQuestoes; i++)
                {
                    q = new Questao();

                    q.Ativo = true;
                    q.Complexidade = random.Next(1, 11);
                    q.TipoQuestao = (TipoDeQuestao)random.Next(1, 5);
                    q.TempoMinimoReutilizacao = 365;
                    q.QtdLinhasEnunciado = 1;
                    q.QtdLinhasResposta = q.TipoQuestao == TipoDeQuestao.Discursiva ? 1 : 0;

                    switch (q.TipoQuestao)
                    {
                        case TipoDeQuestao.Discursiva:
                            q.TempoResposta = q.Complexidade * 30 + 30;
                            q.SequenciaImpressao = "ER";
                            break;
                        case TipoDeQuestao.EscolhaSimples:
                            q.TempoResposta = q.Complexidade * 5 + 30;
                            q.SequenciaImpressao = "EL";
                            break;
                        case TipoDeQuestao.MultiplaEscolha:
                            q.TempoResposta = q.Complexidade * 10 + 30;
                            q.SequenciaImpressao = "EL";
                            break;
                        case TipoDeQuestao.ListaDeAssociacao:
                            q.TempoResposta = q.Complexidade * 15 + 30;
                            q.SequenciaImpressao = "ELA";
                            break;
                    }

                    q.IdDisciplina = random.Next(1, listD.Count + 1);
                    q.Enunciado = "Questão " + q.TipoQuestao.ToString() + " número " + i.ToString()+" (Complexidade "+q.Complexidade.ToString()+", Tempo "+q.TempoResposta.ToString()+")";

                    idQuestao = DBControl.Table<Questao>.Incluir(q);

                    ret = idQuestao != 0;

                    if (!ret)
                        break;

                    if (q.TipoQuestao != TipoDeQuestao.Discursiva)
                    {
                        int id;
                        int ni = random.Next(4, 11);

                        for (int l = 1; l <= ni; l++)
                        {
                            qi = new QuestaoItemEscolha();

                            qi.IdQuestao = idQuestao;
                            qi.Descricao = (q.TipoQuestao == TipoDeQuestao.MultiplaEscolha ? "Múltipla " : "") + "Escolha número " + l.ToString();
                            qi.QtdLinhasOcupadas = 1;

                            id = DBControl.Table<QuestaoItemEscolha>.Incluir(qi);

                            ret = id != 0;

                            if (!ret)
                                break;

                            if (q.TipoQuestao == TipoDeQuestao.ListaDeAssociacao)
                            {
                                qa = new QuestaoItemAssociacao();

                                qa.IdQuestao = idQuestao;
                                qa.Codigo = Encoding.ASCII.GetString(new byte[] { (byte)(l+64) });
                                qa.Descricao = "Item de associação número " + l.ToString();
                                qa.QtdLinhasOcupadas = 1;

                                id = DBControl.Table<QuestaoItemAssociacao>.Incluir(qa);

                                ret = id != 0;

                                if (!ret)
                                    break;
                            }
                        }
                    }

                    if (!ret)
                        break;

                    IncPrbValue(1);
                }
            }

            return ret;
        }

        private void FormCargaInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !btnFechar.Enabled;
        }

        private void rdbGerarNovas_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(true);
        }

        private void rdbRemoverExistentes_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(true);
        }

        private void cboDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableControls(true);
        }
        private void FormCargaInicial_Activated(object sender, EventArgs e)
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

            return ret;
        }

        private void numQtdQuestoes_ValueChanged(object sender, EventArgs e)
        {
            EnableControls(true);
        }
    }
}
