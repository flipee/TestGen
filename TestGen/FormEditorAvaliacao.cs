using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TestGen
{
    public partial class FormEditorAvaliacao : Form
    {
        StringReader leitor = null;

        public FormEditorAvaliacao()
        {
            InitializeComponent();
        }

        private void mnuAbrir_Click(object sender, EventArgs e)
        {
            AbrirArquivo();
        }

        private void AbrirArquivo()
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = true;
            this.ofd1.Title = "Selecionar Arquivo";
            ofd1.InitialDirectory = @"C:\Dados\";
            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "Images (*.TXT)|*.TXT|" + "All files (*.*)|*.*";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 1;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true;

            DialogResult dr = this.ofd1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(ofd1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader m_streamReader = new StreamReader(fs);
                    // Lê o arquivo usando a classe StreamReader
                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    // Lê cada linha do stream e faz o parse até a última linha
                    this.rtxtb1.Text = "";
                    string strLine = m_streamReader.ReadLine();
                    while (strLine != null)
                    {
                        this.rtxtb1.Text += strLine + "\n";
                        strLine = m_streamReader.ReadLine();
                    }
                    // fecha o stream
                    m_streamReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        

        private void mnuAlteraFonte_Click(object sender, EventArgs e)
        {
            AlterarFonte();
        }

        private void AlterarFonte()
        {
            DialogResult result = fontdlg1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (rtxtb1.SelectionFont != null)
                {
                    rtxtb1.SelectionFont = fontdlg1.Font;
                }
            }
        }

        private void mnuNovo_Click(object sender, EventArgs e)
        {
            ChamaSalvarArquivo();
            rtxtb1.Clear();
            rtxtb1.Focus();
        }

        private void ChamaSalvarArquivo()
        {
            if (!string.IsNullOrEmpty(rtxtb1.Text))
            {
                if ((MessageBox.Show("Deseja Salvar o arquivo?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    Salvar_Arquivo();
                }
            }
        }

        private void Salvar_Arquivo()
        {
            try
            {
                // Pega o nome do arquivo para salvar
                if (this.svdlg1.ShowDialog() == DialogResult.OK)
                {
                    // abre um stream para escrita e cria um StreamWriter para implementar o stream
                    FileStream fs = new FileStream(svdlg1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter m_streamWriter = new StreamWriter(fs);
                    m_streamWriter.Flush();
                    // Escreve para o arquivo usando a classe StreamWriter
                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    // escreve no controle richtextbox
                    m_streamWriter.Write(this.rtxtb1.Text);
                    // fecha o arquivo
                    m_streamWriter.Flush();
                    m_streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuSalvar_Click(object sender, EventArgs e)
        {
            ChamaSalvarArquivo();
        }

        private void toolStripNovo_Click(object sender, EventArgs e)
        {
            ChamaSalvarArquivo();
            rtxtb1.Clear();
            rtxtb1.Focus();
        }

        private void toolStripAbrir_Click(object sender, EventArgs e)
        {
            AbrirArquivo();
        }

        private void mnuNegrito_Click(object sender, EventArgs e)
        {
            Negritar();
        }

        private void Negritar()
        {
            string nome_fonte = null;
            float tamanho_fonte = 0;
            bool negrito = false;
            nome_fonte = rtxtb1.Font.Name;
            tamanho_fonte = rtxtb1.Font.Size;
            negrito = rtxtb1.Font.Bold;
            if (negrito == false)
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Bold);
            }
            else
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Regular);
            }
        }

        private void toolStripNegrito_Click(object sender, EventArgs e)
        {
            Negritar();
        }

        private void Copiar()
        {
            if (rtxtb1.SelectionLength > 0)
            {
                rtxtb1.Copy();
            }
        }

        private void Colar()
        {
            rtxtb1.Paste();
        }

        private void mnuCopiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void mnuColar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            ChamaSalvarArquivo();
        }

        private void toolStripCopiar_Click(object sender, EventArgs e)
        {
            //Copiar();
            mnuCopiar.PerformClick();
        }

        private void toolStripColar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void mnuItalico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void Italico()
        {
            string nome_fonte = null;
            float tamanho_fonte = 0;
            bool italico = false;
            nome_fonte = rtxtb1.Font.Name;
            tamanho_fonte = rtxtb1.Font.Size;
            italico = rtxtb1.Font.Italic;

            if (italico == false)
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Italic);
            }
            else
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Italic);
            }
        }

        private void toolStripItalico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void Sublinhar()
        {
            string nome_fonte = null;
            float tamanho_fonte = 0;
            bool sublinha = false;
            nome_fonte = rtxtb1.Font.Name;
            tamanho_fonte = rtxtb1.Font.Size;
            sublinha = rtxtb1.Font.Underline;
            if (sublinha == false)
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Underline);
            }
            else
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Underline);
            }
        }

        private void mnuSublinhado_Click(object sender, EventArgs e)
        {
            Sublinhar();
        }

        private void toolStripSublinhado_Click(object sender, EventArgs e)
        {
            Sublinhar();
        }

        private void toolStripFonte_Click(object sender, EventArgs e)
        {
            AlterarFonte();
        }

        private void prntdoc1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPorPagina = 0;
            float Posicao_Y = 0;
            int contador = 0;

            //defina as margens e o valor minimo
            float MargemEsquerda = e.MarginBounds.Left - 50;
            float MargemSuperior = e.MarginBounds.Top- 50;

            if (MargemEsquerda < 5)
                MargemEsquerda = 20;

            if (MargemSuperior < 5)
                MargemSuperior = 20;
            
            //define a fonte 
            string linha = null;
            Font FonteDeImpressao = this.rtxtb1.Font;
            SolidBrush meupincel = new SolidBrush(Color.Black);
            //StreamReader leitor = null;

            //Calcula o numero de linhas por página usando as medidas das margens
            linhasPorPagina = e.MarginBounds.Height / FonteDeImpressao.GetHeight(e.Graphics);

            // Vamos imprimir cada linha implementando um StringReader
            linha = leitor.ReadLine();

            while (contador < linhasPorPagina)
            {
                // calcula a posicao da proxima linha baseado  na altura da fonte de acordo com o dispostivo de impressao
                Posicao_Y = (MargemSuperior + (contador * FonteDeImpressao.GetHeight(e.Graphics)));
                // desenha a proxima linha no controle richtext
                e.Graphics.DrawString(linha, FonteDeImpressao, meupincel, MargemEsquerda, Posicao_Y, new StringFormat());
                //conta a linha e incrementa uma unidade
                contador += 1;
                linha = leitor.ReadLine();
            }

            // se existir mais linhas imprime outra página
            if ((linha != null))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            meupincel.Dispose();
        }

        private void visualizaImpressao()
        {
            //visualiza a impressao
            try
            {
                string strTexto = this.rtxtb1.Text;
                leitor = new StringReader(strTexto);
                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                var prn = printPreviewDialog1;
                prn.Document = this.prntdoc1;
                prn.Text = "Visualizando a impressão";
                prn.WindowState = FormWindowState.Maximized;
                prn.PrintPreviewControl.Zoom = 1;
                prn.FormBorderStyle = FormBorderStyle.Fixed3D;
                prn.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Imprimir()
        {
            prntdlg1.Document = prntdoc1;

            string strTexto = this.rtxtb1.Text;
            leitor = new StringReader(strTexto);
            if (prntdlg1.ShowDialog() == DialogResult.OK)
            {
                this.prntdoc1.Print();
            }
        }

        private void mnuVisualizarImpressão_Click(object sender, EventArgs e)
        {
            visualizaImpressao();
        }

        private void toolStripVisualizar_Click(object sender, EventArgs e)
        {
            visualizaImpressao();
        }

       
       

        private void ConfiguracoesImpressora()
        {
            try
            {
                this.prntdlg1.Document = this.prntdoc1;
                prntdlg1.ShowDialog();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuConfiguracoesImpressora_Click(object sender, EventArgs e)
        {
            ConfiguracoesImpressora();
        }

        private void mnuAlinharEsquerda_Click(object sender, EventArgs e)
        {
            rtxtb1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void mnuAlinhaDireita_Click(object sender, EventArgs e)
        {
            rtxtb1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void mnuAlinharCentro_Click(object sender, EventArgs e)
        {
            rtxtb1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rtxtb1.Undo();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            rtxtb1.Redo();
        }

        private void toolStripConfigImpressora_Click(object sender, EventArgs e)
        {
            ConfiguracoesImpressora();
        }

        private void mnuImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void toolStripImprimir2_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sair();
        }
        private void Sair()
        {
            if(MessageBox.Show("Deseja sair do Editor?","Sair",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripSair_Click(object sender, EventArgs e)
        {
            Sair();
        }

 
    }
}
