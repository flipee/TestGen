using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormQuestao : Form
    {
        private int id = 0;
        private int idDisciplina = 0;
        private TipoOperacaoCadastro tipoOperacao=TipoOperacaoCadastro.Visualizar;

        private Questao questao = null;
        private List<QuestaoItemEscolha> questaoItensEscolha = null;
        private List<QuestaoItemAssociacao> questaoItensAssociacao = null;

        private List<int> deletedItemEscolhaID = new List<int>();
        private List<int> deletedItemAssociacaoID = new List<int>();

        private bool inLoad = false;

        public event EventHandler<Questao> eventRetorno;
        public void SetEventRetorno(EventHandler<Questao> ev)
        {
            eventRetorno = ev;
        }

        public FormQuestao()
        {
            InitializeComponent();
        }

        public void SetOperacao(TipoOperacaoCadastro tipoOperacao, int id, int idDisciplina)
        {
            this.tipoOperacao = tipoOperacao;
            this.id = id;
            this.idDisciplina = idDisciplina;
        }
        private void FormQuestao_Load(object sender, EventArgs e)
        {
            numComplexidade.Minimum = 1;
            numComplexidade.Maximum = 10;

            numQtdLinhasEnunciado.Minimum = 1;
            numQtdLinhasEnunciado.Maximum = 20;

            numQtdLinhasResposta.Maximum = 0;
            numQtdLinhasResposta.Maximum = 20;

            numTempoMinReutilizacao.Minimum = 1;
            numTempoMinReutilizacao.Maximum = 9999;

            numTempoResposta.Minimum = 1;
            numTempoResposta.Maximum = 999;

            txtID.ReadOnly = true;
            tabControlQuestao.SelectedIndex = 0;

            switch (tipoOperacao)
            {
                case TipoOperacaoCadastro.Visualizar:
                    this.Text = this.Text + " (Visualizar)";
                    break;
                case TipoOperacaoCadastro.Incluir:
                    this.Text = this.Text + " (Incluir)";
                    break;
                case TipoOperacaoCadastro.Alterar:
                    this.Text = this.Text + " (Alterar)";
                    break;
                case TipoOperacaoCadastro.Excluir:
                    this.Text = this.Text + " (Excluir)";
                    btnGravar.Text = "Excluir";
                    break;
            }

            EnableControls();
        }
        private void FormQuestao_Activated(object sender, EventArgs e)
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
                case TipoOperacaoCadastro.Incluir:
                    ret = IncluirQuestao();
                    break;
                case TipoOperacaoCadastro.Alterar:
                    ret = AlterarQuestao();
                    break;
                case TipoOperacaoCadastro.Excluir:
                    if (Mensagem.ShowPerguntaSimNao(this,"Confirma a exclusão do item selecionado?") == DialogResult.Yes)
                    {
                        ret = ExcluirQuestao();
                    }
                    break;
            }

            if (ret && eventRetorno!=null)
            {
                eventRetorno(this, questao);

                this.Close();
            }
        }

        private void EnableControls()
        {
            bool enabled = !(tipoOperacao == TipoOperacaoCadastro.Visualizar || tipoOperacao == TipoOperacaoCadastro.Excluir);

            cboTipoQuestao.Enabled = tipoOperacao == TipoOperacaoCadastro.Incluir;
            TipoDeQuestao tipoQuestao = (TipoDeQuestao)GetIdItemCombo(cboTipoQuestao);

            rchEnunciado.ReadOnly = !enabled;
            chkAtivo.AutoCheck = enabled;
            cboDisciplina.Enabled = enabled && idDisciplina == 0 && tipoOperacao != TipoOperacaoCadastro.Alterar;
            numComplexidade.Enabled = enabled;
            numQtdLinhasEnunciado.Enabled = enabled;
            numQtdLinhasResposta.Enabled = enabled;
            numTempoMinReutilizacao.Enabled = enabled;
            numTempoResposta.Enabled = enabled;
            txtSequenciaImpressao.ReadOnly = !enabled;

            btnAddImagemQuestao.Enabled = enabled;
            btnRemoverImagemQuestao.Enabled = enabled;

            picImagemQuestao.Enabled = enabled && tipoQuestao != TipoDeQuestao.ListaDeAssociacao;

            dgvListaSelecao.ReadOnly = !enabled;
            dgvListaAssociacao.ReadOnly = !enabled;

            if (cboTipoQuestao.Items.Count > 0)
            {
                dgvListaSelecao.ReadOnly = !(enabled && tipoQuestao != TipoDeQuestao.Discursiva && tipoQuestao!=TipoDeQuestao.NaoSelecionado);
                dgvListaAssociacao.ReadOnly = !(enabled && tipoQuestao == TipoDeQuestao.ListaDeAssociacao);
            }

            if (dgvListaSelecao.ReadOnly && (tipoOperacao == TipoOperacaoCadastro.Incluir || tipoOperacao == TipoOperacaoCadastro.Alterar))
            { 
                dgvListaSelecao.Rows.Clear();
            }

            if (dgvListaAssociacao.ReadOnly && (tipoOperacao == TipoOperacaoCadastro.Incluir || tipoOperacao == TipoOperacaoCadastro.Alterar))
            { 
                dgvListaAssociacao.Rows.Clear();
            }

            btnGravar.Visible = tipoOperacao!=TipoOperacaoCadastro.Visualizar;
        }

        private bool ValidarListas()
        {
            bool ret = true;

            if (ret)
            {
                QuestaoItemEscolha qe;

                foreach (DataGridViewRow dgvr in dgvListaSelecao.Rows)
                {
                    if (dgvr.Tag != null && (bool)dgvr.Tag)
                    {
                        qe = DataGridToItemEscolha(dgvr, 1);

                        ret = qe.Validar();

                        if (!ret)
                        {
                            tabControlQuestao.SelectTab(tabQuestaoListaSelecao);
                            dgvr.Selected = true;
                            break;
                        }
                    }
                }
            }

            if (ret)
            {
                QuestaoItemAssociacao qa;

                foreach (DataGridViewRow dgvr in dgvListaAssociacao.Rows)
                {
                    if (dgvr.Tag != null && (bool)dgvr.Tag)
                    {
                        qa = DataGridToItemAssociacao(dgvr, 1);

                        ret = qa.Validar();

                        if (!ret)
                        {
                            tabControlQuestao.SelectTab(tabQuestaoListaAssociacao);
                            dgvr.Selected = true;
                            break;
                        }
                    }
                }
            }

            return ret;
        }
        private bool AtribuirQuestao(bool incluir)
        {
            bool ret = false;

            try
            {
                if (incluir)
                {
                    questao = new Questao();
                }

                questao.Enunciado = rchEnunciado.Text.Trim();
                questao.Ativo = chkAtivo.Checked;
                questao.TipoQuestao = (TipoDeQuestao)GetIdItemCombo(cboTipoQuestao);
                questao.IdDisciplina = GetIdItemCombo(cboDisciplina);
                questao.QtdLinhasEnunciado = (int)numQtdLinhasEnunciado.Value;
                questao.QtdLinhasResposta = (int)numQtdLinhasResposta.Value;
                questao.Complexidade = (int)numComplexidade.Value;
                questao.TempoResposta = (int)numTempoResposta.Value;
                questao.TempoMinimoReutilizacao = (int)numTempoMinReutilizacao.Value;
                questao.SequenciaImpressao = txtSequenciaImpressao.Text;

                if (picImagemQuestao.Image == null)
                    questao.Imagem = null;
                else
                    questao.Imagem = Converter.ImageToByteArray(picImagemQuestao.Image);

                ret = true;
            }
            catch (Exception ex)
            {
                Mensagem.ShowErro("Erro ao atribuir questão!", ex);
            }

            return ret;
        }

        private bool IncluirQuestao()
        {
            bool ret = false;

            if (ValidarListas() && AtribuirQuestao(true))
            {
                DBControl.BeginTrans();

                int idQuestao = DBControl.Table<Questao>.Incluir(questao);
                ret = idQuestao != 0;

                if (ret)
                {
                    ret = AtualizarItensQuestao(idQuestao);
                }

                if (ret)
                    DBControl.CommitAll();
                else
                    DBControl.RollbackAll();
            }

            return ret;
        }
        private bool AlterarQuestao()
        {
            bool ret=false;

            if (ValidarListas() && AtribuirQuestao(false))
            {
                DBControl.BeginTrans();

                ret = DBControl.Table<Questao>.Alterar(questao);

                if (ret)
                {
                    ret = AtualizarItensQuestao(questao.Id);
                }

                if (ret)
                    DBControl.CommitAll();
                else
                    DBControl.RollbackAll();
            }

            return ret;
        }
        private QuestaoItemEscolha DataGridToItemEscolha(DataGridViewRow dgvr,int idQuestao)
        {
            QuestaoItemEscolha qe = new QuestaoItemEscolha();

            qe.Id = dgvr.Cells[0].Value == null ? 0 : (int)dgvr.Cells[0].Value;
            qe.IdQuestao = idQuestao;
            qe.Descricao = dgvr.Cells[1].Value == null ? "" : (string)dgvr.Cells[1].Value;
            qe.QtdLinhasOcupadas = dgvr.Cells[2].Value == null ? 0 : int.Parse((string)dgvr.Cells[2].Value);

            return qe;
        }
        private QuestaoItemAssociacao DataGridToItemAssociacao(DataGridViewRow dgvr, int idQuestao)
        {
            QuestaoItemAssociacao qa = new QuestaoItemAssociacao();
            qa.Id = dgvr.Cells[0].Value == null ? 0 : (int)dgvr.Cells[0].Value;
            qa.IdQuestao = idQuestao;
            qa.Codigo = dgvr.Cells[1].Value == null ? "" : (string)dgvr.Cells[1].Value;
            qa.Descricao = dgvr.Cells[2].Value == null ? "" : (string)dgvr.Cells[2].Value;
            qa.Imagem = Converter.ImageToByteArray((Image)dgvr.Cells[3].Value);
            qa.QtdLinhasOcupadas = dgvr.Cells[4].Value == null ? 0 : int.Parse((string)dgvr.Cells[4].Value);

            return qa;
        }
        private bool AtualizarItensQuestao(int idQuestao)
        {
            bool ret=true;

            if (ret)
            {
                foreach(int id in deletedItemEscolhaID)
                {
                    ret = DBControl.Table<QuestaoItemEscolha>.Excluir(id);

                    if (!ret)
                        break;
                }
            }

            if (ret)
            {
                foreach (int id in deletedItemAssociacaoID)
                {
                    ret = DBControl.Table<QuestaoItemAssociacao>.Excluir(id);

                    if (!ret)
                        break;
                }
            }

            if (ret)
            {
                QuestaoItemEscolha qe;

                foreach (DataGridViewRow dgvr in dgvListaSelecao.Rows)
                {
                    if (dgvr.Tag!=null && (bool)dgvr.Tag)
                    {
                        qe = DataGridToItemEscolha(dgvr,idQuestao);

                        ret = DBControl.Table<QuestaoItemEscolha>.AutoIncluir(qe) > 0;

                        if (!ret)
                            break;
                    }
                }
            }

            if (ret)
            {
                QuestaoItemAssociacao qa;

                foreach (DataGridViewRow dgvr in dgvListaAssociacao.Rows)
                {
                    if (dgvr.Tag != null && (bool)dgvr.Tag)
                    {
                        qa = DataGridToItemAssociacao(dgvr, idQuestao);

                        ret = DBControl.Table<QuestaoItemAssociacao>.AutoIncluir(qa) > 0;

                        if (!ret)
                            break;
                    }
                }
            }

            return ret;
        }

        private bool ExcluirQuestao()
        {
            bool ret = true;

            DBControl.BeginTrans();

            if (ret)
            {
                foreach (QuestaoItemEscolha qe in questaoItensEscolha)
                {
                    ret = DBControl.Table<QuestaoItemEscolha>.Excluir(qe.Id);

                    if (!ret)
                        break;
                }
            }

            if (ret)
            {
                foreach (QuestaoItemAssociacao qa in questaoItensAssociacao)
                {
                    ret = DBControl.Table<QuestaoItemAssociacao>.Excluir(qa.Id);

                    if (!ret)
                        break;
                }
            }

            if (ret)
                ret = DBControl.Table<Questao>.Excluir(questao.Id);

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

            chkAtivo.Checked = true;
            cboTipoQuestao.Focus();

            if (tipoOperacao != TipoOperacaoCadastro.Incluir)
            {
                questao = DBControl.Table<Questao>.Ler(id);

                if (questao != null)
                {
                    txtID.Text = questao.Id.ToString();
                    rchEnunciado.Text = questao.Enunciado;
                    chkAtivo.Checked = questao.Ativo;
                    SelectComboBoxByValue(cboTipoQuestao, (int)questao.TipoQuestao);
                    SelectComboBoxByValue(cboDisciplina, questao.IdDisciplina);
                    numQtdLinhasEnunciado.Value = questao.QtdLinhasEnunciado;
                    numQtdLinhasResposta.Value = questao.QtdLinhasResposta;
                    numComplexidade.Value = questao.Complexidade;
                    numTempoResposta.Value = questao.TempoResposta;
                    numTempoMinReutilizacao.Value = questao.TempoMinimoReutilizacao;
                    txtSequenciaImpressao.Text = questao.SequenciaImpressao;

                    if (questao.Imagem == null)
                        picImagemQuestao.Image = null;
                    else
                        picImagemQuestao.Image = Converter.ByteArrayToImage(questao.Imagem);
                }

                if (questao == null)
                {
                    Mensagem.ShowAlerta(this,"Não foi possível ler a Questao com ID " + id.ToString() + "!");

                    ret = false;
                }

                if (questao!=null )
                {
                    questaoItensEscolha = DBControl.Table<QuestaoItemEscolha>.Pesquisar(x => x.IdQuestao == questao.Id);
                    questaoItensAssociacao = DBControl.Table<QuestaoItemAssociacao>.Pesquisar(x => x.IdQuestao == questao.Id);

                    if (questaoItensEscolha!=null && questaoItensEscolha.Count > 0)
                    {
                        DataGridViewRow dgvr = null;

                        foreach (QuestaoItemEscolha qe in questaoItensEscolha)
                        {
                            dgvr = new DataGridViewRow();

                            dgvListaSelecao.Rows.Add(qe.Id, qe.Descricao, qe.QtdLinhasOcupadas.ToString());
                        }
                    }
                    if (questaoItensAssociacao != null && questaoItensAssociacao.Count > 0)
                    {
                        DataGridViewRow dgvr = null;
                        Image image = null;

                        foreach (QuestaoItemAssociacao qa in questaoItensAssociacao)
                        {
                            dgvr = new DataGridViewRow();

                            image= Converter.ByteArrayToImage(qa.Imagem);

                            dgvListaAssociacao.Rows.Add(qa.Id, qa.Codigo, qa.Descricao, image, qa.QtdLinhasOcupadas.ToString());
                        }
                    }
                }
            }

            if (ret && !CarregarCombos())
            {
                Mensagem.ShowAlerta(this,"Não foi possível carregar Disciplinas e Cursos!");

                ret = false;
            }

            inLoad = false;

            Cursor.Current = Cursors.Default;

            return ret;
        }

        private bool CarregarCombos()
        {
            bool ret = CarregarComboTipoCadastro(cboTipoQuestao);

            if (ret)
            {
                if (tipoOperacao == TipoOperacaoCadastro.Visualizar || tipoOperacao == TipoOperacaoCadastro.Excluir)
                {
                    ret = CarregarCombo<Disciplina>(cboDisciplina, questao.IdDisciplina);
                }
                else
                {
                    ret = CarregarComboAtivo<Disciplina>(cboDisciplina);
                }
            }

            if (ret)
            {
                if (tipoOperacao != TipoOperacaoCadastro.Incluir)
                {
                    SelectComboBoxByValue(cboTipoQuestao, (int)questao.TipoQuestao);
                    SelectComboBoxByValue(cboDisciplina, questao.IdDisciplina);
                }
                else if (idDisciplina != 0)
                {
                    SelectComboBoxByValue(cboDisciplina, idDisciplina);
                }
            }

            return ret;
        }

        private void cboTipoQuestao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inLoad)
                EnableControls();
        }

        private void btnAddImagemQuestao_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "jpg|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                picImagemQuestao.ImageLocation = file.FileName;
            }
        }

        private void btnRemoverImagemQuestao_Click(object sender, EventArgs e)
        {
            picImagemQuestao.Image = null;
        }

        private void contextMenuImagem_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = dgvListaAssociacao.ReadOnly || dgvListaAssociacao.SelectedRows.Count == 0;

            if (!e.Cancel)
            {
                string descricao = (string)dgvListaAssociacao.SelectedRows[0].Cells[2].Value;

                e.Cancel = descricao == null || descricao.Equals("");
            }
        }

        private void menuListaAssociacaoImagemAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "jpg|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(file.FileName);

                dgvListaAssociacao.SelectedRows[0].Cells[3].Value = image;
            }
        }

        private void menuListaAssociacaoImagemRemover_Click(object sender, EventArgs e)
        {
            dgvListaAssociacao.Rows[dgvListaAssociacao.SelectedCells[0].RowIndex].Cells[3].Value = null;
        }
        private void dgvListaSelecao_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            object value = e.Row.Cells[0].Value;

            if (value != null)
            {
                deletedItemEscolhaID.Add((int)value);
            }
        }
        private void dgvListaAssociacao_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            object value = e.Row.Cells[0].Value;

            if (value != null)
            {
                deletedItemAssociacaoID.Add((int)value);
            }
        }

        private void dgvListaSelecao_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0 && !inLoad)
            {
                dgvListaSelecao.Rows[e.RowIndex].Tag = true;
            }
        }
        private void dgvListaAssociacao_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !inLoad)
            {
                dgvListaAssociacao.Rows[e.RowIndex].Tag = true;
            }
        }
    }
}

