using System;
using System.Windows.Forms;

namespace TestGen
{
    public partial class FormPesquisar : Form
    {
        public event EventHandler<PesquisaEventArgs> eventPesquisa;
        public void SetEventPesquisa(EventHandler<PesquisaEventArgs> ev)
        {
            eventPesquisa = ev;
        }
        public FormPesquisar()
        {
            InitializeComponent();
        }

        private void FormPesquisar_Load(object sender, EventArgs e)
        {
            optTipoPesquisaCodigo.Select();
        }

        private void optTipoPesquisaCodigo_CheckedChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }

        private void optTipoPesquisaNome_CheckedChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }

        private void optTipoPesquisaTodos_CheckedChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }

        private void HabilitaBotoes()
        {
            txtCodigo.Enabled = optTipoPesquisaCodigo.Checked;
            txtNome.Enabled = optTipoPesquisaNome.Checked;

            if (!txtCodigo.Enabled)
                txtCodigo.Text = "";

            if (!txtNome.Enabled)
                txtNome.Text = "";

            btnPesquisar.Enabled = optTipoPesquisaTodos.Checked || !(txtCodigo.Text.Equals("") && txtNome.Text.Equals(""));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (eventPesquisa!=null)
            {
                TipoDaPesquisa tipopesquisa = TipoDaPesquisa.Nenhum;
                String pesquisa = "";

                if (optTipoPesquisaCodigo.Checked)
                {
                    tipopesquisa = TipoDaPesquisa.PorCodigo;
                    pesquisa = txtCodigo.Text;
                }
                else if(optTipoPesquisaNome.Checked)
                {
                    tipopesquisa = TipoDaPesquisa.PorNome;
                    pesquisa = txtNome.Text;
                }
                else if (optTipoPesquisaTodos.Checked)
                {
                    tipopesquisa = TipoDaPesquisa.Todos;
                }

                PesquisaEventArgs evp = new PesquisaEventArgs(tipopesquisa,pesquisa);

                eventPesquisa(this, evp);
            }

            this.Close();
        }
    }
}
