namespace TestGen
{
    partial class FormConfigurarInstituicao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNomeInstituicao = new System.Windows.Forms.Label();
            this.txtNomeInstituicao = new System.Windows.Forms.TextBox();
            this.lblLogotipoInstituicao = new System.Windows.Forms.Label();
            this.pnlAvaliacoes = new System.Windows.Forms.Panel();
            this.numQtdDiasRepetirAvaliacao = new System.Windows.Forms.NumericUpDown();
            this.numQtdQuestoes = new System.Windows.Forms.NumericUpDown();
            this.lblQuantidadeQuestoes = new System.Windows.Forms.Label();
            this.lblDiasRepetirAvaliação = new System.Windows.Forms.Label();
            this.lblAvaliacoes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoverLogo = new System.Windows.Forms.Button();
            this.btnAddLogo = new System.Windows.Forms.Button();
            this.picLogotipo = new System.Windows.Forms.PictureBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlAvaliacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdDiasRepetirAvaliacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdQuestoes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogotipo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomeInstituicao
            // 
            this.lblNomeInstituicao.AutoSize = true;
            this.lblNomeInstituicao.Location = new System.Drawing.Point(9, 9);
            this.lblNomeInstituicao.Name = "lblNomeInstituicao";
            this.lblNomeInstituicao.Size = new System.Drawing.Size(136, 17);
            this.lblNomeInstituicao.TabIndex = 0;
            this.lblNomeInstituicao.Text = "Nome da Instituição:";
            // 
            // txtNomeInstituicao
            // 
            this.txtNomeInstituicao.Location = new System.Drawing.Point(12, 29);
            this.txtNomeInstituicao.MaxLength = 80;
            this.txtNomeInstituicao.Name = "txtNomeInstituicao";
            this.txtNomeInstituicao.Size = new System.Drawing.Size(648, 22);
            this.txtNomeInstituicao.TabIndex = 1;
            // 
            // lblLogotipoInstituicao
            // 
            this.lblLogotipoInstituicao.AutoSize = true;
            this.lblLogotipoInstituicao.Location = new System.Drawing.Point(9, 64);
            this.lblLogotipoInstituicao.Name = "lblLogotipoInstituicao";
            this.lblLogotipoInstituicao.Size = new System.Drawing.Size(154, 17);
            this.lblLogotipoInstituicao.TabIndex = 2;
            this.lblLogotipoInstituicao.Text = "Logotipo da Instituição:";
            // 
            // pnlAvaliacoes
            // 
            this.pnlAvaliacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAvaliacoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAvaliacoes.Controls.Add(this.numQtdDiasRepetirAvaliacao);
            this.pnlAvaliacoes.Controls.Add(this.numQtdQuestoes);
            this.pnlAvaliacoes.Controls.Add(this.lblQuantidadeQuestoes);
            this.pnlAvaliacoes.Controls.Add(this.lblDiasRepetirAvaliação);
            this.pnlAvaliacoes.Location = new System.Drawing.Point(12, 250);
            this.pnlAvaliacoes.Name = "pnlAvaliacoes";
            this.pnlAvaliacoes.Size = new System.Drawing.Size(648, 43);
            this.pnlAvaliacoes.TabIndex = 9;
            // 
            // numQtdDiasRepetirAvaliacao
            // 
            this.numQtdDiasRepetirAvaliacao.Location = new System.Drawing.Point(496, 9);
            this.numQtdDiasRepetirAvaliacao.Name = "numQtdDiasRepetirAvaliacao";
            this.numQtdDiasRepetirAvaliacao.Size = new System.Drawing.Size(68, 22);
            this.numQtdDiasRepetirAvaliacao.TabIndex = 18;
            // 
            // numQtdQuestoes
            // 
            this.numQtdQuestoes.Location = new System.Drawing.Point(188, 9);
            this.numQtdQuestoes.Name = "numQtdQuestoes";
            this.numQtdQuestoes.Size = new System.Drawing.Size(68, 22);
            this.numQtdQuestoes.TabIndex = 17;
            // 
            // lblQuantidadeQuestoes
            // 
            this.lblQuantidadeQuestoes.AutoSize = true;
            this.lblQuantidadeQuestoes.Location = new System.Drawing.Point(14, 11);
            this.lblQuantidadeQuestoes.Name = "lblQuantidadeQuestoes";
            this.lblQuantidadeQuestoes.Size = new System.Drawing.Size(168, 17);
            this.lblQuantidadeQuestoes.TabIndex = 14;
            this.lblQuantidadeQuestoes.Text = "Quantidade de questões:";
            // 
            // lblDiasRepetirAvaliação
            // 
            this.lblDiasRepetirAvaliação.AutoSize = true;
            this.lblDiasRepetirAvaliação.Location = new System.Drawing.Point(284, 11);
            this.lblDiasRepetirAvaliação.Name = "lblDiasRepetirAvaliação";
            this.lblDiasRepetirAvaliação.Size = new System.Drawing.Size(206, 17);
            this.lblDiasRepetirAvaliação.TabIndex = 12;
            this.lblDiasRepetirAvaliação.Text = "Qtd. dias não repetir avaliação:";
            // 
            // lblAvaliacoes
            // 
            this.lblAvaliacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAvaliacoes.AutoSize = true;
            this.lblAvaliacoes.Location = new System.Drawing.Point(12, 229);
            this.lblAvaliacoes.Name = "lblAvaliacoes";
            this.lblAvaliacoes.Size = new System.Drawing.Size(80, 17);
            this.lblAvaliacoes.TabIndex = 10;
            this.lblAvaliacoes.Text = "Avaliações:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRemoverLogo);
            this.panel1.Controls.Add(this.btnAddLogo);
            this.panel1.Controls.Add(this.picLogotipo);
            this.panel1.Location = new System.Drawing.Point(12, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 133);
            this.panel1.TabIndex = 11;
            // 
            // btnRemoverLogo
            // 
            this.btnRemoverLogo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRemoverLogo.Location = new System.Drawing.Point(540, 76);
            this.btnRemoverLogo.Name = "btnRemoverLogo";
            this.btnRemoverLogo.Size = new System.Drawing.Size(91, 36);
            this.btnRemoverLogo.TabIndex = 6;
            this.btnRemoverLogo.Text = "Remover";
            this.btnRemoverLogo.UseVisualStyleBackColor = true;
            this.btnRemoverLogo.Click += new System.EventHandler(this.btnRemoverLogo_Click);
            // 
            // btnAddLogo
            // 
            this.btnAddLogo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddLogo.Location = new System.Drawing.Point(540, 18);
            this.btnAddLogo.Name = "btnAddLogo";
            this.btnAddLogo.Size = new System.Drawing.Size(91, 36);
            this.btnAddLogo.TabIndex = 5;
            this.btnAddLogo.Text = "Adicionar";
            this.btnAddLogo.UseVisualStyleBackColor = true;
            this.btnAddLogo.Click += new System.EventHandler(this.btnAddLogo_Click);
            // 
            // picLogotipo
            // 
            this.picLogotipo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogotipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogotipo.Location = new System.Drawing.Point(-1, -1);
            this.picLogotipo.Name = "picLogotipo";
            this.picLogotipo.Size = new System.Drawing.Size(526, 133);
            this.picLogotipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogotipo.TabIndex = 4;
            this.picLogotipo.TabStop = false;
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravar.Location = new System.Drawing.Point(472, 308);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(91, 36);
            this.btnGravar.TabIndex = 12;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(569, 308);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(91, 36);
            this.btnFechar.TabIndex = 13;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormConfigurarInstituicao
            // 
            this.AcceptButton = this.btnGravar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(672, 353);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAvaliacoes);
            this.Controls.Add(this.pnlAvaliacoes);
            this.Controls.Add(this.lblLogotipoInstituicao);
            this.Controls.Add(this.txtNomeInstituicao);
            this.Controls.Add(this.lblNomeInstituicao);
            this.MinimumSize = new System.Drawing.Size(690, 400);
            this.Name = "FormConfigurarInstituicao";
            this.Text = "Configuração da Instituição";
            this.Load += new System.EventHandler(this.frmConfigurarInstituicao_Load);
            this.pnlAvaliacoes.ResumeLayout(false);
            this.pnlAvaliacoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdDiasRepetirAvaliacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdQuestoes)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogotipo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomeInstituicao;
        private System.Windows.Forms.TextBox txtNomeInstituicao;
        private System.Windows.Forms.Label lblLogotipoInstituicao;
        private System.Windows.Forms.Panel pnlAvaliacoes;
        private System.Windows.Forms.Label lblQuantidadeQuestoes;
        private System.Windows.Forms.Label lblDiasRepetirAvaliação;
        private System.Windows.Forms.Label lblAvaliacoes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoverLogo;
        private System.Windows.Forms.Button btnAddLogo;
        private System.Windows.Forms.PictureBox picLogotipo;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.NumericUpDown numQtdDiasRepetirAvaliacao;
        private System.Windows.Forms.NumericUpDown numQtdQuestoes;
    }
}