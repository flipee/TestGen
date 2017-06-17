using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestGen
{
    public partial class FormConfigurarInstituicao : Form
    {
        Instituicao instituicao = null;
        public FormConfigurarInstituicao()
        {
            InitializeComponent();
        }
        private void frmConfigurarInstituicao_Load(object sender, EventArgs e)
        {
            numQtdQuestoes.Minimum = 5;
            numQtdQuestoes.Maximum = 100;
            numQtdDiasRepetirAvaliacao.Minimum = 1;
            numQtdDiasRepetirAvaliacao.Maximum = 9999;

            List<Instituicao> list = DBControl.Table<Instituicao>.Pesquisar();

            if (list.Count() > 0)
                instituicao = list.ElementAt(0);

            if (instituicao != null)
            {
                txtNomeInstituicao.Text = instituicao.Nome;
                numQtdDiasRepetirAvaliacao.Value = instituicao.QtdNaoRepetirAvaliacao;
                numQtdQuestoes.Value = instituicao.QtdQuestoesAvaliacao;

                if (instituicao.Logotipo == null)
                    picLogotipo.Image = null;
                else
                    picLogotipo.Image = Converter.ByteArrayToImage(instituicao.Logotipo);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (instituicao==null)
                instituicao=new Instituicao();

            instituicao.Nome = txtNomeInstituicao.Text;
            instituicao.QtdNaoRepetirAvaliacao = (int)numQtdDiasRepetirAvaliacao.Value;
            instituicao.QtdQuestoesAvaliacao = (int)numQtdQuestoes.Value;

            if (picLogotipo.Image == null)
                instituicao.Logotipo = null;
            else
                instituicao.Logotipo = Converter.ImageToByteArray(picLogotipo.Image);

            int id = DBControl.Table<Instituicao>.AutoIncluir(instituicao);
            
            if (id > 0)
            {
                DBControl.Instituicao = DBControl.Table<Instituicao>.Ler(id);

                this.Close();
            }
        }

        private void btnAddLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "jpg|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                picLogotipo.ImageLocation = file.FileName;
            }
        }

        private void btnRemoverLogo_Click(object sender, EventArgs e)
        {
            picLogotipo.Image = null;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
