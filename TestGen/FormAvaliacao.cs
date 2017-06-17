using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormAvaliacao : Form
    {
        private int id = 0;
        private TipoOperacaoCadastro tipoOperacao=TipoOperacaoCadastro.Visualizar;

        private Avaliacao avaliacao = null;
        private List<AvaliacaoQuestao> avaliacaoQuestoes = null;

        private bool inLoad;

        public event EventHandler<Avaliacao> eventRetorno;
        public void SetEventRetorno(EventHandler<Avaliacao> ev)
        {
            eventRetorno = ev;
        }

        public FormAvaliacao()
        {
            InitializeComponent();
        }

        public void SetOperacao(TipoOperacaoCadastro tipoOperacao, int id)
        {
            this.tipoOperacao = tipoOperacao;
            this.id = id;
        }
        private void FormAvaliacao_Load(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            txtCodigo.Enabled = false;
            txtDescricao.Enabled = false;
            txtDataGeracao.Enabled = false;

            cboDisciplina.Enabled = false;

            numQtdTotQuestaoDiscursiva.Maximum = Decimal.MaxValue;
            numQtdTotQuestaoEscolhaSimples.Maximum = Decimal.MaxValue;
            numQtdTotQuestaoMultiplaEscolha.Maximum = Decimal.MaxValue;
            numQtdTotQuestaoListaAssociacao.Maximum = Decimal.MaxValue;

            numQtdTotComplex1.Maximum = Decimal.MaxValue;
            numQtdTotComplex2.Maximum = Decimal.MaxValue;
            numQtdTotComplex3.Maximum = Decimal.MaxValue;
            numQtdTotComplex4.Maximum = Decimal.MaxValue;
            numQtdTotComplex5.Maximum = Decimal.MaxValue;
            numQtdTotComplex6.Maximum = Decimal.MaxValue;
            numQtdTotComplex7.Maximum = Decimal.MaxValue;
            numQtdTotComplex8.Maximum = Decimal.MaxValue;
            numQtdTotComplex9.Maximum = Decimal.MaxValue;
            numQtdTotComplex10.Maximum = Decimal.MaxValue;

            numQuantidadeQuestoes.Maximum = Decimal.MaxValue;
            numTempoTotalPrevisto.Maximum = Decimal.MaxValue;
            numQtdLinhasUtilizadas.Maximum = Decimal.MaxValue;

            numQtdTotQuestaoDiscursiva.Enabled = false;
            numQtdTotQuestaoEscolhaSimples.Enabled = false;
            numQtdTotQuestaoMultiplaEscolha.Enabled = false;
            numQtdTotQuestaoListaAssociacao.Enabled = false;

            numQtdTotComplex1.Enabled = false;
            numQtdTotComplex2.Enabled = false;
            numQtdTotComplex3.Enabled = false;
            numQtdTotComplex4.Enabled = false;
            numQtdTotComplex5.Enabled = false;
            numQtdTotComplex6.Enabled = false;
            numQtdTotComplex7.Enabled = false;
            numQtdTotComplex8.Enabled = false;
            numQtdTotComplex9.Enabled = false;
            numQtdTotComplex10.Enabled = false;

            numQuantidadeQuestoes.Enabled = false;
            numTempoTotalPrevisto.Enabled = false;
            numQtdLinhasUtilizadas.Enabled = false;

            dgvListaQuestoes.ReadOnly = true;

            tabControlAvaliacao.SelectedIndex = 0;

            switch (tipoOperacao)
            {
                case TipoOperacaoCadastro.Visualizar:
                    this.Text = this.Text + " (Visualizar)";
                    break;
                case TipoOperacaoCadastro.Excluir:
                    this.Text = this.Text + " (Excluir)";
                    btnGravar.Text = "Excluir";
                    break;
            }

            EnableControls();
        }
        private void FormAvaliacao_Activated(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Tag = true;

                if (!CarregarDados())
                    this.Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            bool ret = false;

            switch (tipoOperacao)
            {
                case TipoOperacaoCadastro.Excluir:
                    if (Mensagem.ShowPerguntaSimNao(this,"Confirma a exclusão do item selecionado?") == DialogResult.Yes)
                    {
                        ret = ExcluirAvaliacao();
                    }
                    break;
            }

            if (ret && eventRetorno!=null)
            {
                eventRetorno(this, avaliacao);

                this.Close();
            }
        }

        private void EnableControls()
        {
            btnGravar.Visible = tipoOperacao!=TipoOperacaoCadastro.Visualizar;
        }

        private bool ExcluirAvaliacao()
        {
            bool ret = true;

            DBControl.BeginTrans();

            int idAvaliacao = avaliacao.Id;

            if (ret)
            {

                List<AvaliacaoQuestao> listaAQ = DBControl.Table<AvaliacaoQuestao>.Pesquisar(x => x.IdAvaliacao == idAvaliacao);

                foreach (AvaliacaoQuestao aq in listaAQ)
                {
                    ret = DBControl.Table<AvaliacaoQuestao>.Excluir(aq.Id);

                    if (!ret)
                        break;
                }
            }

            if (ret)
                ret = DBControl.Table<Avaliacao>.Excluir(idAvaliacao);

            if (ret)
                DBControl.CommitAll();
            else
                DBControl.RollbackAll();

            return ret;
        }

        private bool CarregarDados()
        {
            bool ret = true;

            Cursor.Current = Cursors.WaitCursor;

            inLoad = true;

            avaliacao = DBControl.Table<Avaliacao>.Ler(id);

            if (avaliacao != null)
            {
                txtID.Text = avaliacao.Id.ToString();
                txtCodigo.Text = avaliacao.Codigo.ToString();
                txtDescricao.Text = avaliacao.Descricao.ToString();
                txtDataGeracao.Text = avaliacao.DtGeracao.ToShortDateString();
            }

            if (avaliacao == null)
            {
                Mensagem.ShowAlerta(this,"Não foi possível ler a Avaliacao com ID " + id.ToString() + "!");

                ret = false;
            }

            int[] qtdTotTipoQuestao = { 0, 0, 0, 0 };

            int[] qtdTotComplex = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            int quantidadeQuestoes = 0;
            int tempoTotalPrevisto = 0;
            int qtdLinhasUtilizadas = 0;

            if (ret)
            {
                avaliacaoQuestoes = DBControl.Table<AvaliacaoQuestao>.Pesquisar(x => x.IdAvaliacao == avaliacao.Id);

                if (avaliacaoQuestoes != null && avaliacaoQuestoes.Count > 0)
                {
                    DataGridViewRow dgvr = null;
                    Questao questao = null;

                    foreach (AvaliacaoQuestao aq in avaliacaoQuestoes)
                    {
                        questao = DBControl.Table<Questao>.Ler(aq.IdQuestao);

                        List<QuestaoItemEscolha> listaQE = DBControl.Table<QuestaoItemEscolha>.Pesquisar(x => x.IdQuestao == aq.IdQuestao);
                        List<QuestaoItemAssociacao> listaQA = DBControl.Table<QuestaoItemAssociacao>.Pesquisar(x => x.IdQuestao == aq.IdQuestao);

                        dgvr = new DataGridViewRow();

                        dgvListaQuestoes.Rows.Add(aq.IdQuestao, questao.Enunciado, aq.DtGeracao.ToShortDateString());

                        qtdTotTipoQuestao[(int)questao.TipoQuestao - 1]++;
                        qtdTotComplex[questao.Complexidade-1]++;
                        quantidadeQuestoes++;
                        tempoTotalPrevisto += questao.TempoResposta;

                        qtdLinhasUtilizadas += questao.QtdLinhasEnunciado;

                        if (questao.TipoQuestao==TipoDeQuestao.Discursiva)
                            qtdLinhasUtilizadas += questao.QtdLinhasResposta;
                        else
                        {
                            foreach (QuestaoItemEscolha qe in listaQE)
                                qtdLinhasUtilizadas += qe.QtdLinhasOcupadas;

                            foreach (QuestaoItemAssociacao qa in listaQA)
                                qtdLinhasUtilizadas += qa.QtdLinhasOcupadas;
                        }
                    }
                }
            }

            if (ret)
            {
                numQtdTotQuestaoDiscursiva.Value = qtdTotTipoQuestao[(int)TipoDeQuestao.Discursiva-1];
                numQtdTotQuestaoEscolhaSimples.Value = qtdTotTipoQuestao[(int)TipoDeQuestao.EscolhaSimples - 1];
                numQtdTotQuestaoMultiplaEscolha.Value = qtdTotTipoQuestao[(int)TipoDeQuestao.MultiplaEscolha - 1];
                numQtdTotQuestaoListaAssociacao.Value = qtdTotTipoQuestao[(int)TipoDeQuestao.ListaDeAssociacao - 1];

                numQtdTotComplex1.Value = qtdTotComplex[0];
                numQtdTotComplex2.Value = qtdTotComplex[1];
                numQtdTotComplex3.Value = qtdTotComplex[2];
                numQtdTotComplex4.Value = qtdTotComplex[3];
                numQtdTotComplex5.Value = qtdTotComplex[4];
                numQtdTotComplex6.Value = qtdTotComplex[5];
                numQtdTotComplex7.Value = qtdTotComplex[6];
                numQtdTotComplex8.Value = qtdTotComplex[7];
                numQtdTotComplex9.Value = qtdTotComplex[8];
                numQtdTotComplex10.Value = qtdTotComplex[9];

                numQuantidadeQuestoes.Value = quantidadeQuestoes;
                numTempoTotalPrevisto.Value = tempoTotalPrevisto;
                numQtdLinhasUtilizadas.Value = qtdLinhasUtilizadas;
            }


            if (ret && !CarregarCombos())
            {
                Mensagem.ShowAlerta(this,"Não foi possível carregar Disciplinas!");

                ret = false;
            }

            inLoad = false;

            Cursor.Current = Cursors.Default;

            return ret;
        }

        private bool CarregarCombos()
        {
            bool ret = CarregarCombo<Disciplina>(cboDisciplina, avaliacao.IdDisciplina);

            if (ret)
                SelectComboBoxByValue(cboDisciplina,avaliacao.IdDisciplina);
    
            return ret;
        }

        private void dgvListaQuestoes_DoubleClick(object sender, EventArgs e)
        {
            if (dgvListaQuestoes.SelectedRows.Count>0)
            {
                DataGridViewRow dgvr = dgvListaQuestoes.SelectedRows[0];

                VisualizarQuestao((int)dgvr.Cells[0].Value);
            }

        }

        private void VisualizarQuestao(int idQUestao)
        {
            FormQuestao frmQuestao = new FormQuestao();

            frmQuestao.SetOperacao(TipoOperacaoCadastro.Visualizar, idQUestao,0);

            frmQuestao.ShowDialog(this);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //DGVPrinter printer = new DGVPrinter();
            //printer.Title = avaliacao.Descricao.ToString();
            //printer.SubTitle = string.Format("Data: {0}", avaliacao.DtGeracao.ToString("dd/MM/yyyy"));
            //printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //printer.PageNumbers = true;
            //printer.PageNumberInHeader = false;
            //printer.PorportionalColumns = true;
            //printer.HeaderCellAlignment = StringAlignment.Near;
            //printer.Footer = avaliacao.Codigo.ToString();
            ////printer.PrintPreviewNoDisplay(dgvListaQuestoes);

            FormEditorAvaliacao frmEditor = new FormEditorAvaliacao();
            frmEditor.ShowDialog(this);
            
        }
      
    }
}

