namespace TestGen
{
    partial class FormExecutaGeracaoAvaliacao
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
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.grpResultado = new System.Windows.Forms.GroupBox();
            this.btnParar = new System.Windows.Forms.Button();
            this.txtGeracao = new System.Windows.Forms.TextBox();
            this.txtTempoProcessamento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFitness = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxResultado = new System.Windows.Forms.RichTextBox();
            this.txtQtdQuestoesDisponiveis = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravar.Location = new System.Drawing.Point(597, 537);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(91, 36);
            this.btnGravar.TabIndex = 33;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(694, 537);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(91, 36);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // grpResultado
            // 
            this.grpResultado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResultado.Controls.Add(this.txtGeracao);
            this.grpResultado.Controls.Add(this.txtQtdQuestoesDisponiveis);
            this.grpResultado.Controls.Add(this.label5);
            this.grpResultado.Controls.Add(this.txtTempoProcessamento);
            this.grpResultado.Controls.Add(this.label4);
            this.grpResultado.Controls.Add(this.txtTempo);
            this.grpResultado.Controls.Add(this.label3);
            this.grpResultado.Controls.Add(this.txtFitness);
            this.grpResultado.Controls.Add(this.label2);
            this.grpResultado.Controls.Add(this.label1);
            this.grpResultado.Location = new System.Drawing.Point(12, 12);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(773, 74);
            this.grpResultado.TabIndex = 35;
            this.grpResultado.TabStop = false;
            this.grpResultado.Text = "Processamento";
            // 
            // btnParar
            // 
            this.btnParar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParar.Location = new System.Drawing.Point(499, 537);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(91, 36);
            this.btnParar.TabIndex = 34;
            this.btnParar.Text = "Parar";
            this.btnParar.UseVisualStyleBackColor = true;
            // 
            // txtGeracao
            // 
            this.txtGeracao.Location = new System.Drawing.Point(9, 40);
            this.txtGeracao.Name = "txtGeracao";
            this.txtGeracao.Size = new System.Drawing.Size(140, 22);
            this.txtGeracao.TabIndex = 8;
            // 
            // txtTempoProcessamento
            // 
            this.txtTempoProcessamento.Location = new System.Drawing.Point(476, 40);
            this.txtTempoProcessamento.Name = "txtTempoProcessamento";
            this.txtTempoProcessamento.Size = new System.Drawing.Size(140, 22);
            this.txtTempoProcessamento.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tempo Proc. (Segs.):";
            // 
            // txtTempo
            // 
            this.txtTempo.Location = new System.Drawing.Point(330, 40);
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(140, 22);
            this.txtTempo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tempo Prev. Resp.:";
            // 
            // txtFitness
            // 
            this.txtFitness.Location = new System.Drawing.Point(155, 40);
            this.txtFitness.Name = "txtFitness";
            this.txtFitness.Size = new System.Drawing.Size(169, 22);
            this.txtFitness.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fitness:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Geração:";
            // 
            // rtxResultado
            // 
            this.rtxResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxResultado.Location = new System.Drawing.Point(12, 92);
            this.rtxResultado.Name = "rtxResultado";
            this.rtxResultado.Size = new System.Drawing.Size(773, 430);
            this.rtxResultado.TabIndex = 36;
            this.rtxResultado.Text = "";
            // 
            // txtQtdQuestoesDisponiveis
            // 
            this.txtQtdQuestoesDisponiveis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQtdQuestoesDisponiveis.Location = new System.Drawing.Point(623, 40);
            this.txtQtdQuestoesDisponiveis.Name = "txtQtdQuestoesDisponiveis";
            this.txtQtdQuestoesDisponiveis.Size = new System.Drawing.Size(140, 22);
            this.txtQtdQuestoesDisponiveis.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(620, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Qtd. Questões Disp.:";
            // 
            // FormExecutaGeracaoAvaliacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 585);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.rtxResultado);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnFechar);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(815, 500);
            this.Name = "FormExecutaGeracaoAvaliacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerando avaliação";
            this.Activated += new System.EventHandler(this.FormExecutaGeracaoAvaliacao_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExecutaGeracaoAvaliacao_FormClosing);
            this.Load += new System.EventHandler(this.FormExecutaGeracaoAvaliacao_Load);
            this.grpResultado.ResumeLayout(false);
            this.grpResultado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox grpResultado;
        private System.Windows.Forms.TextBox txtFitness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxResultado;
        private System.Windows.Forms.TextBox txtTempoProcessamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGeracao;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.TextBox txtQtdQuestoesDisponiveis;
        private System.Windows.Forms.Label label5;
    }
}