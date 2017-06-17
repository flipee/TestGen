using System;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormProfessor : Form
    {
        private int id = 0;
        private TipoOperacaoCadastro tipoOperacao=TipoOperacaoCadastro.Visualizar;

        private Professor professor = null;

        public event EventHandler<Professor> eventRetorno;
        public void SetEventRetorno(EventHandler<Professor> ev)
        {
            eventRetorno = ev;
        }

        public FormProfessor()
        {
            InitializeComponent();
        }

        public void SetOperacao(TipoOperacaoCadastro tipoOperacao, int id)
        {
            this.tipoOperacao = tipoOperacao;
            this.id = id;
        }

        private void FormProfessor_Load(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;

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

        private void FormProfessor_Activated(object sender, EventArgs e)
        {
            if (this.Tag==null)
            {
                this.Tag = true;
                chkAtivo.Checked = true;
                txtCodigo.Focus();

                if (tipoOperacao!= TipoOperacaoCadastro.Incluir)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    professor = DBControl.Table<Professor>.Ler(id);

                    if (professor != null)
                    {
                        txtID.Text = professor.Id.ToString();
                        txtCodigo.Text = professor.Codigo;
                        txtNome.Text = professor.Nome;
                        txtEmail.Text = professor.Email;
                        chkAtivo.Checked = professor.Ativo;
                    }

                    Cursor.Current = Cursors.Default;

                    if (professor == null)
                    {
                        Mensagem.ShowAlerta(this,"Não foi possível ler o Professor com ID " + id.ToString() + "!");

                        this.Close();
                    }
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            bool ret = false;

            if (tipoOperacao == TipoOperacaoCadastro.Incluir)
            {
                professor = new Professor();
            }

            professor.Codigo = txtCodigo.Text.Trim();
            professor.Nome = txtNome.Text.Trim();
            professor.Email = txtEmail.Text.Trim();
            professor.Ativo = chkAtivo.Checked;

            switch (tipoOperacao)
            {
                case TipoOperacaoCadastro.Incluir:
                    professor.Id = DBControl.Table<Professor>.Incluir(professor);
                    ret = professor.Id != 0;
                    break;
                case TipoOperacaoCadastro.Alterar:
                    ret = DBControl.Table<Professor>.Alterar(professor);
                    break;
                case TipoOperacaoCadastro.Excluir:
                    if (Mensagem.ShowPerguntaSimNao(this,"Confirma a exclusão do item selecionado?") == DialogResult.Yes)
                    {
                        ret = DBControl.Table<Professor>.Excluir(professor.Id);
                    }
                    break;
            }

            if (ret && eventRetorno!=null)
            {
                eventRetorno(this, professor);

                this.Close();
            }
        }
        private void EnableControls()
        {
            bool enabled = !(tipoOperacao == TipoOperacaoCadastro.Visualizar || tipoOperacao == TipoOperacaoCadastro.Excluir);

            txtCodigo.ReadOnly = !enabled;
            txtNome.ReadOnly = !enabled;
            chkAtivo.AutoCheck = enabled;

            btnGravar.Visible = tipoOperacao != TipoOperacaoCadastro.Visualizar;
        }
    }
}
