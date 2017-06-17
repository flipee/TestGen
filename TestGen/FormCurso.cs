using System;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormCurso : Form
    {
        private int id = 0;
        private TipoOperacaoCadastro tipoOperacao=TipoOperacaoCadastro.Visualizar;

        private Curso curso = null;

        public event EventHandler<Curso> eventRetorno;
        public void SetEventRetorno(EventHandler<Curso> ev)
        {
            eventRetorno = ev;
        }

        public FormCurso()
        {
            InitializeComponent();
        }

        public void SetOperacao(TipoOperacaoCadastro tipoOperacao, int id)
        {
            this.tipoOperacao = tipoOperacao;
            this.id = id;
        }

        private void FormCurso_Load(object sender, EventArgs e)
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

        private void FormCurso_Activated(object sender, EventArgs e)
        {
            if (this.Tag==null)
            {
                this.Tag = true;
                chkAtivo.Checked = true;
                txtCodigo.Focus();

                if (tipoOperacao!= TipoOperacaoCadastro.Incluir)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    curso = DBControl.Table<Curso>.Ler(id);

                    if (curso!=null)
                    {
                        txtID.Text = curso.Id.ToString();
                        txtCodigo.Text = curso.Codigo;
                        txtNome.Text = curso.Nome;
                        chkAtivo.Checked = curso.Ativo;
                    }

                    Cursor.Current = Cursors.Default;

                    if (curso==null)
                    {
                        Mensagem.ShowAlerta(this,"Não foi possível ler o curso com ID " + id.ToString() + "!");

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
                curso = new Curso();
            }

            curso.Codigo = txtCodigo.Text.Trim();
            curso.Nome = txtNome.Text.Trim();
            curso.Ativo = chkAtivo.Checked;

            switch (tipoOperacao)
            {
                case TipoOperacaoCadastro.Incluir:
                    curso.Id = DBControl.Table<Curso>.Incluir(curso);
                    ret = curso.Id != 0;
                    break;
                case TipoOperacaoCadastro.Alterar:
                    ret = DBControl.Table<Curso>.Alterar(curso);
                    break;
                case TipoOperacaoCadastro.Excluir:
                    if (Mensagem.ShowPerguntaSimNao(this,"Confirma a exclusão do item selecionado?") == DialogResult.Yes)
                    {
                        ret = DBControl.Table<Curso>.Excluir(curso.Id);
                    }
                    break;
            }

            if (ret && eventRetorno!=null)
            {
                eventRetorno(this, curso);

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
