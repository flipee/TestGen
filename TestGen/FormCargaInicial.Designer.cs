namespace TestGen
{
    partial class FormCargaInicial
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
            this.numQtdQuestoes = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.prbGeracaoQuestoes = new System.Windows.Forms.ProgressBar();
            this.cboDisciplina = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbGerarNovas = new System.Windows.Forms.RadioButton();
            this.rdbRemoverExistentes = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdQuestoes)).BeginInit();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // numQtdQuestoes
            // 
            this.numQtdQuestoes.Location = new System.Drawing.Point(579, 68);
            this.numQtdQuestoes.Name = "numQtdQuestoes";
            this.numQtdQuestoes.Size = new System.Drawing.Size(83, 22);
            this.numQtdQuestoes.TabIndex = 18;
            this.numQtdQuestoes.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numQtdQuestoes.ValueChanged += new System.EventHandler(this.numQtdQuestoes_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Quantidade de Questões:";
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravar.Location = new System.Drawing.Point(474, 157);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(91, 36);
            this.btnGravar.TabIndex = 20;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(571, 157);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(91, 36);
            this.btnFechar.TabIndex = 19;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.lblStatus);
            this.pnlProgress.Controls.Add(this.prbGeracaoQuestoes);
            this.pnlProgress.Location = new System.Drawing.Point(12, 96);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(649, 49);
            this.pnlProgress.TabIndex = 22;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 1);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(261, 17);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Gerando questões. Por favor aguarde...";
            // 
            // prbGeracaoQuestoes
            // 
            this.prbGeracaoQuestoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prbGeracaoQuestoes.Location = new System.Drawing.Point(6, 20);
            this.prbGeracaoQuestoes.Name = "prbGeracaoQuestoes";
            this.prbGeracaoQuestoes.Size = new System.Drawing.Size(636, 23);
            this.prbGeracaoQuestoes.TabIndex = 22;
            // 
            // cboDisciplina
            // 
            this.cboDisciplina.FormattingEnabled = true;
            this.cboDisciplina.Location = new System.Drawing.Point(12, 31);
            this.cboDisciplina.Name = "cboDisciplina";
            this.cboDisciplina.Size = new System.Drawing.Size(649, 24);
            this.cboDisciplina.TabIndex = 24;
            this.cboDisciplina.SelectedIndexChanged += new System.EventHandler(this.cboDisciplina_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Disciplina:";
            // 
            // rdbGerarNovas
            // 
            this.rdbGerarNovas.AutoSize = true;
            this.rdbGerarNovas.Location = new System.Drawing.Point(12, 68);
            this.rdbGerarNovas.Name = "rdbGerarNovas";
            this.rdbGerarNovas.Size = new System.Drawing.Size(183, 21);
            this.rdbGerarNovas.TabIndex = 25;
            this.rdbGerarNovas.TabStop = true;
            this.rdbGerarNovas.Text = "Remover e Gerar Novas";
            this.rdbGerarNovas.UseVisualStyleBackColor = true;
            this.rdbGerarNovas.CheckedChanged += new System.EventHandler(this.rdbGerarNovas_CheckedChanged);
            // 
            // rdbRemoverExistentes
            // 
            this.rdbRemoverExistentes.AutoSize = true;
            this.rdbRemoverExistentes.Location = new System.Drawing.Point(201, 68);
            this.rdbRemoverExistentes.Name = "rdbRemoverExistentes";
            this.rdbRemoverExistentes.Size = new System.Drawing.Size(146, 21);
            this.rdbRemoverExistentes.TabIndex = 26;
            this.rdbRemoverExistentes.TabStop = true;
            this.rdbRemoverExistentes.Text = "Somente Remover";
            this.rdbRemoverExistentes.UseVisualStyleBackColor = true;
            this.rdbRemoverExistentes.CheckedChanged += new System.EventHandler(this.rdbRemoverExistentes_CheckedChanged);
            // 
            // FormCargaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 205);
            this.Controls.Add(this.rdbRemoverExistentes);
            this.Controls.Add(this.rdbGerarNovas);
            this.Controls.Add(this.cboDisciplina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.numQtdQuestoes);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCargaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Carga Inicial Randômica de Questões";
            this.Activated += new System.EventHandler(this.FormCargaInicial_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCargaInicial_FormClosing);
            this.Load += new System.EventHandler(this.FormCargaInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQtdQuestoes)).EndInit();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numQtdQuestoes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar prbGeracaoQuestoes;
        private System.Windows.Forms.ComboBox cboDisciplina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbGerarNovas;
        private System.Windows.Forms.RadioButton rdbRemoverExistentes;
    }
}