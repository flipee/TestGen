using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGen
{
    public partial class FormExportarExcel : Form
    {
        public FormExportarExcel()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormExportarExcel_Load(object sender, EventArgs e)
        {

        }

        private void btnSelArquivo_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "Planilhas Excel|*.xlsx";
            saveFileDlg.Title = "Salvar planilha excel";

            if (saveFileDlg.ShowDialog() == DialogResult.OK && !saveFileDlg.FileName.Equals(""))
            {
                txtArquivo.Text = saveFileDlg.FileName;
            }
        }
    }
}
