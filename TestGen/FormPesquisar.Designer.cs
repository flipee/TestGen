namespace TestGen
{
    partial class FormPesquisar
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.optTipoPesquisaCodigo = new System.Windows.Forms.RadioButton();
            this.optTipoPesquisaNome = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.optTipoPesquisaTodos = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(15, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(123, 22);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(15, 81);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(545, 22);
            this.txtNome.TabIndex = 3;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // optTipoPesquisaCodigo
            // 
            this.optTipoPesquisaCodigo.AutoSize = true;
            this.optTipoPesquisaCodigo.Location = new System.Drawing.Point(15, 119);
            this.optTipoPesquisaCodigo.Name = "optTipoPesquisaCodigo";
            this.optTipoPesquisaCodigo.Size = new System.Drawing.Size(99, 21);
            this.optTipoPesquisaCodigo.TabIndex = 4;
            this.optTipoPesquisaCodigo.TabStop = true;
            this.optTipoPesquisaCodigo.Text = "Por Código";
            this.optTipoPesquisaCodigo.UseVisualStyleBackColor = true;
            this.optTipoPesquisaCodigo.CheckedChanged += new System.EventHandler(this.optTipoPesquisaCodigo_CheckedChanged);
            // 
            // optTipoPesquisaNome
            // 
            this.optTipoPesquisaNome.AutoSize = true;
            this.optTipoPesquisaNome.Location = new System.Drawing.Point(134, 119);
            this.optTipoPesquisaNome.Name = "optTipoPesquisaNome";
            this.optTipoPesquisaNome.Size = new System.Drawing.Size(149, 21);
            this.optTipoPesquisaNome.TabIndex = 5;
            this.optTipoPesquisaNome.TabStop = true;
            this.optTipoPesquisaNome.Text = "Por parte do Nome";
            this.optTipoPesquisaNome.UseVisualStyleBackColor = true;
            this.optTipoPesquisaNome.CheckedChanged += new System.EventHandler(this.optTipoPesquisaNome_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(469, 159);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 36);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(372, 159);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(91, 36);
            this.btnPesquisar.TabIndex = 7;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // optTipoPesquisaTodos
            // 
            this.optTipoPesquisaTodos.AutoSize = true;
            this.optTipoPesquisaTodos.Location = new System.Drawing.Point(304, 119);
            this.optTipoPesquisaTodos.Name = "optTipoPesquisaTodos";
            this.optTipoPesquisaTodos.Size = new System.Drawing.Size(212, 21);
            this.optTipoPesquisaTodos.TabIndex = 8;
            this.optTipoPesquisaTodos.TabStop = true;
            this.optTipoPesquisaTodos.Text = "Retornar Todos os Registros";
            this.optTipoPesquisaTodos.UseVisualStyleBackColor = true;
            this.optTipoPesquisaTodos.CheckedChanged += new System.EventHandler(this.optTipoPesquisaTodos_CheckedChanged);
            // 
            // FormPesquisar
            // 
            this.AcceptButton = this.btnPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(572, 206);
            this.Controls.Add(this.optTipoPesquisaTodos);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.optTipoPesquisaNome);
            this.Controls.Add(this.optTipoPesquisaCodigo);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPesquisar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisar";
            this.Load += new System.EventHandler(this.FormPesquisar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton optTipoPesquisaCodigo;
        private System.Windows.Forms.RadioButton optTipoPesquisaNome;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton optTipoPesquisaTodos;
    }
}