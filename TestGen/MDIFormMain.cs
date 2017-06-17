using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestGen
{
    public partial class MDIFormMain : Form
    {
        FormConfigurarInstituicao frmConfigurarInstituicao = null;
        FormCadastroCursos frmCadastroCursos = null;
        FormCadastroProfessores frmCadastroProfessores = null;
        FormCadastroDisciplinas frmCadastroDisciplinas = null;
        FormCadastroQuestoes frmCadastroQuestoes = null;
        FormGerarAvaliacao frmGerarAvaliacao = null;
        FormCadastroAvaliacoes frmCadastroAvaliacoes = null;

        public MDIFormMain()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIFormMain_Load(object sender, EventArgs e)
        {
            DBControl.Inicializar();
            List<Instituicao> lista = DBControl.Table<Instituicao>.Pesquisar();
            if(lista!=null && lista.Count>0)
            {
                DBControl.Instituicao = lista[0];
            }
        }

        private void mnuConfigurarInstituicao_Click(object sender, EventArgs e)
        {
            if (frmConfigurarInstituicao == null || frmConfigurarInstituicao.IsDisposed)
            {
                frmConfigurarInstituicao = new FormConfigurarInstituicao();
                frmConfigurarInstituicao.MdiParent = this;
            }

            frmConfigurarInstituicao.Show();
        }

        private void mnuCadastroCursos_Click(object sender, EventArgs e)
        {
            if (!DBControl.CheckInstituicao())
                return;

            if (frmCadastroCursos == null || frmCadastroCursos.IsDisposed)
            {
                frmCadastroCursos = new FormCadastroCursos();
                frmCadastroCursos.MdiParent = this;
            }

            frmCadastroCursos.Show();
        }

        private void MDIFormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBControl.Finalizar();
        }

        private void mnuCadastroProfessores_Click(object sender, EventArgs e)
        {
            if (!DBControl.CheckInstituicao())
                return;

            if (frmCadastroProfessores == null || frmCadastroProfessores.IsDisposed)
            {
                frmCadastroProfessores = new FormCadastroProfessores();
                frmCadastroProfessores.MdiParent = this;
            }

            frmCadastroProfessores.Show();
        }

        private void mnuCadastroDisciplinas_Click(object sender, EventArgs e)
        {
            if (!DBControl.CheckInstituicao())
                return;

            if (frmCadastroDisciplinas == null || frmCadastroDisciplinas.IsDisposed)
            {
                frmCadastroDisciplinas = new FormCadastroDisciplinas();
                frmCadastroDisciplinas.MdiParent = this;
            }

            frmCadastroDisciplinas.Show();
        }
        private void mnuCadastroQuestoes_Click(object sender, EventArgs e)
        {
            if (!DBControl.CheckInstituicao())
                return;

            if (frmCadastroQuestoes == null || frmCadastroQuestoes.IsDisposed)
            {
                frmCadastroQuestoes = new FormCadastroQuestoes();
                frmCadastroQuestoes.MdiParent = this;
            }

            frmCadastroQuestoes.Show();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSobre frmSobre = new FormSobre();

            frmSobre.ShowDialog(this);
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensagem.ShowNaoImplementado(this);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensagem.ShowNaoImplementado(this);
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensagem.ShowNaoImplementado(this);
        }

        private void menuGerarAvaliacao_Click(object sender, EventArgs e)
        {
            if (!DBControl.CheckInstituicao())
                return;

            if (frmGerarAvaliacao == null || frmGerarAvaliacao.IsDisposed)
            {
                frmGerarAvaliacao = new FormGerarAvaliacao();
                frmGerarAvaliacao.MdiParent = this;
            }

            frmGerarAvaliacao.Show();
        }

        private void mnuCargaInicial_Click(object sender, EventArgs e)
        {
            FormCargaInicial formCargaInicial = new FormCargaInicial();

            formCargaInicial.ShowDialog(this);
        }

        private void menuCadastroAvaliacoes_Click(object sender, EventArgs e)
        {
            if (!DBControl.CheckInstituicao())
                return;

            if (frmCadastroAvaliacoes == null || frmCadastroAvaliacoes.IsDisposed)
            {
                frmCadastroAvaliacoes = new FormCadastroAvaliacoes();
                frmCadastroAvaliacoes.MdiParent = this;
            }

            frmCadastroAvaliacoes.Show();
        }
    }
}
