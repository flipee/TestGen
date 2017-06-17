using System;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormDisciplina : Form
    {
        private int id = 0;
        private TipoOperacaoCadastro tipoOperacao=TipoOperacaoCadastro.Visualizar;

        private Disciplina disciplina = null;

        public event EventHandler<Disciplina> eventRetorno;
        public void SetEventRetorno(EventHandler<Disciplina> ev)
        {
            eventRetorno = ev;
        }

        public FormDisciplina()
        {
            InitializeComponent();
        }

        public void SetOperacao(TipoOperacaoCadastro tipoOperacao, int id)
        {
            this.tipoOperacao = tipoOperacao;
            this.id = id;
        }
        private void FormDisciplina_Load(object sender, EventArgs e)
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
        private void FormDisciplina_Activated(object sender, EventArgs e)
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

            if (tipoOperacao == TipoOperacaoCadastro.Incluir)
            {
                disciplina = new Disciplina();
            }

            disciplina.Codigo = txtCodigo.Text.Trim();
            disciplina.Nome = txtNome.Text.Trim();
            disciplina.Ativo = chkAtivo.Checked;
            disciplina.IdProfessor = GetIdItemCombo(cboProfessor);
            disciplina.IdCurso = GetIdItemCombo(cboCurso);

            switch (tipoOperacao)
            {
                case TipoOperacaoCadastro.Incluir:
                    disciplina.Id = DBControl.Table<Disciplina>.Incluir(disciplina);
                    ret = disciplina.Id != 0;
                    break;
                case TipoOperacaoCadastro.Alterar:
                    ret = DBControl.Table<Disciplina>.Alterar(disciplina);
                    break;
                case TipoOperacaoCadastro.Excluir:
                    if (Mensagem.ShowPerguntaSimNao(this,"Confirma a exclusão do item selecionado?") == DialogResult.Yes)
                    {
                        ret = DBControl.Table<Disciplina>.Excluir(disciplina.Id);
                    }
                    break;
            }

            if (ret && eventRetorno!=null)
            {
                eventRetorno(this, disciplina);

                this.Close();
            }
        }

        private void EnableControls()
        {
            bool enabled = !(tipoOperacao == TipoOperacaoCadastro.Visualizar || tipoOperacao == TipoOperacaoCadastro.Excluir);

            txtCodigo.ReadOnly = !(enabled && tipoOperacao == TipoOperacaoCadastro.Incluir);
            txtNome.ReadOnly = !enabled;
            chkAtivo.AutoCheck = enabled;
            cboProfessor.Enabled = enabled;
            cboCurso.Enabled = enabled;

            btnGravar.Visible = tipoOperacao!=TipoOperacaoCadastro.Visualizar;
        }

        private bool CarregarDados()
        {
            bool ret = true;

            Cursor.Current = Cursors.WaitCursor;

            chkAtivo.Checked = true;
            txtCodigo.Focus();

            if (tipoOperacao != TipoOperacaoCadastro.Incluir)
            {
                disciplina = DBControl.Table<Disciplina>.Ler(id);

                if (disciplina != null)
                {
                    txtID.Text = disciplina.Id.ToString();
                    txtCodigo.Text = disciplina.Codigo;
                    txtNome.Text = disciplina.Nome;
                    chkAtivo.Checked = disciplina.Ativo;
                }

                if (disciplina == null)
                {
                    Mensagem.ShowAlerta(this,"Não foi possível ler a Disciplina com ID " + id.ToString() + "!");

                    ret = false;
                }
            }

            if (ret && !CarregarCombos())
            {
                Mensagem.ShowAlerta(this,"Não foi possível carregar Professores e Cursos!");

                ret = false;
            }

            Cursor.Current = Cursors.Default;

            return ret;
        }

        private bool CarregarCombos()
        {
            bool ret;

            if (tipoOperacao == TipoOperacaoCadastro.Visualizar || tipoOperacao == TipoOperacaoCadastro.Excluir)
            {
                ret = CarregarCombo<Professor>(cboProfessor, disciplina.IdProfessor);

                if (ret)
                    ret = CarregarCombo<Curso>(cboCurso, disciplina.IdCurso);
            }
            else
            {
                ret = CarregarComboAtivo<Professor>(cboProfessor);

                if (ret)
                    ret = CarregarComboAtivo<Curso>(cboCurso);
            }

            if (ret && tipoOperacao != TipoOperacaoCadastro.Incluir)
            {
                SelectComboBoxByValue(cboProfessor,disciplina.IdProfessor);
                SelectComboBoxByValue(cboCurso, disciplina.IdCurso);
            }

            return ret;
        }
    }
}
