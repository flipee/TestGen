namespace TestGen
{
    partial class FormQuestao
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDisciplina = new System.Windows.Forms.ComboBox();
            this.cboTipoQuestao = new System.Windows.Forms.ComboBox();
            this.tabControlQuestao = new System.Windows.Forms.TabControl();
            this.tabQuestaoConfiguracao = new System.Windows.Forms.TabPage();
            this.txtSequenciaImpressao = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numQtdLinhasResposta = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numQtdLinhasEnunciado = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numTempoMinReutilizacao = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numTempoResposta = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numComplexidade = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rchEnunciado = new System.Windows.Forms.RichTextBox();
            this.tabQuestaoImagem = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoverImagemQuestao = new System.Windows.Forms.Button();
            this.btnAddImagemQuestao = new System.Windows.Forms.Button();
            this.picImagemQuestao = new System.Windows.Forms.PictureBox();
            this.tabQuestaoListaSelecao = new System.Windows.Forms.TabPage();
            this.dgvListaSelecao = new System.Windows.Forms.DataGridView();
            this.ListaSelecaoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListaSelecaoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListaSelecaoQtdLinhas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabQuestaoListaAssociacao = new System.Windows.Forms.TabPage();
            this.dgvListaAssociacao = new System.Windows.Forms.DataGridView();
            this.ListaAssociacaoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListaAssociacaoCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListaAssociacaoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListaAssociacaoImagem = new System.Windows.Forms.DataGridViewImageColumn();
            this.contextMenuImagem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuListaAssociacaoImagemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuListaAssociacaoImagemRemover = new System.Windows.Forms.ToolStripMenuItem();
            this.ListaAssociacaoQtdLinhas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlQuestao.SuspendLayout();
            this.tabQuestaoConfiguracao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdLinhasResposta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdLinhasEnunciado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempoMinReutilizacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempoResposta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numComplexidade)).BeginInit();
            this.tabQuestaoImagem.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagemQuestao)).BeginInit();
            this.tabQuestaoListaSelecao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSelecao)).BeginInit();
            this.tabQuestaoListaAssociacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAssociacao)).BeginInit();
            this.contextMenuImagem.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(15, 29);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo:";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(408, 29);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 21);
            this.chkAtivo.TabIndex = 6;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(622, 542);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(91, 36);
            this.btnFechar.TabIndex = 7;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravar.Location = new System.Drawing.Point(525, 542);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(91, 36);
            this.btnGravar.TabIndex = 8;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Disciplina:";
            // 
            // cboDisciplina
            // 
            this.cboDisciplina.FormattingEnabled = true;
            this.cboDisciplina.Location = new System.Drawing.Point(15, 83);
            this.cboDisciplina.Name = "cboDisciplina";
            this.cboDisciplina.Size = new System.Drawing.Size(649, 24);
            this.cboDisciplina.TabIndex = 10;
            // 
            // cboTipoQuestao
            // 
            this.cboTipoQuestao.FormattingEnabled = true;
            this.cboTipoQuestao.Location = new System.Drawing.Point(145, 27);
            this.cboTipoQuestao.Name = "cboTipoQuestao";
            this.cboTipoQuestao.Size = new System.Drawing.Size(235, 24);
            this.cboTipoQuestao.TabIndex = 13;
            this.cboTipoQuestao.SelectedIndexChanged += new System.EventHandler(this.cboTipoQuestao_SelectedIndexChanged);
            // 
            // tabControlQuestao
            // 
            this.tabControlQuestao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlQuestao.Controls.Add(this.tabQuestaoConfiguracao);
            this.tabControlQuestao.Controls.Add(this.tabQuestaoImagem);
            this.tabControlQuestao.Controls.Add(this.tabQuestaoListaSelecao);
            this.tabControlQuestao.Controls.Add(this.tabQuestaoListaAssociacao);
            this.tabControlQuestao.Location = new System.Drawing.Point(12, 125);
            this.tabControlQuestao.Name = "tabControlQuestao";
            this.tabControlQuestao.SelectedIndex = 0;
            this.tabControlQuestao.Size = new System.Drawing.Size(702, 408);
            this.tabControlQuestao.TabIndex = 14;
            // 
            // tabQuestaoConfiguracao
            // 
            this.tabQuestaoConfiguracao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabQuestaoConfiguracao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabQuestaoConfiguracao.Controls.Add(this.txtSequenciaImpressao);
            this.tabQuestaoConfiguracao.Controls.Add(this.label10);
            this.tabQuestaoConfiguracao.Controls.Add(this.numQtdLinhasResposta);
            this.tabQuestaoConfiguracao.Controls.Add(this.label9);
            this.tabQuestaoConfiguracao.Controls.Add(this.numQtdLinhasEnunciado);
            this.tabQuestaoConfiguracao.Controls.Add(this.label8);
            this.tabQuestaoConfiguracao.Controls.Add(this.numTempoMinReutilizacao);
            this.tabQuestaoConfiguracao.Controls.Add(this.label7);
            this.tabQuestaoConfiguracao.Controls.Add(this.numTempoResposta);
            this.tabQuestaoConfiguracao.Controls.Add(this.label6);
            this.tabQuestaoConfiguracao.Controls.Add(this.numComplexidade);
            this.tabQuestaoConfiguracao.Controls.Add(this.label5);
            this.tabQuestaoConfiguracao.Controls.Add(this.label3);
            this.tabQuestaoConfiguracao.Controls.Add(this.rchEnunciado);
            this.tabQuestaoConfiguracao.Location = new System.Drawing.Point(4, 25);
            this.tabQuestaoConfiguracao.Name = "tabQuestaoConfiguracao";
            this.tabQuestaoConfiguracao.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuestaoConfiguracao.Size = new System.Drawing.Size(694, 379);
            this.tabQuestaoConfiguracao.TabIndex = 0;
            this.tabQuestaoConfiguracao.Text = "Configuração";
            // 
            // txtSequenciaImpressao
            // 
            this.txtSequenciaImpressao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSequenciaImpressao.Location = new System.Drawing.Point(619, 345);
            this.txtSequenciaImpressao.Name = "txtSequenciaImpressao";
            this.txtSequenciaImpressao.Size = new System.Drawing.Size(61, 22);
            this.txtSequenciaImpressao.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(446, 348);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "Sequência Impressão:";
            // 
            // numQtdLinhasResposta
            // 
            this.numQtdLinhasResposta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numQtdLinhasResposta.Location = new System.Drawing.Point(369, 346);
            this.numQtdLinhasResposta.Name = "numQtdLinhasResposta";
            this.numQtdLinhasResposta.Size = new System.Drawing.Size(61, 22);
            this.numQtdLinhasResposta.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 348);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Qtd. Lin. Resposta:";
            // 
            // numQtdLinhasEnunciado
            // 
            this.numQtdLinhasEnunciado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numQtdLinhasEnunciado.Location = new System.Drawing.Point(149, 346);
            this.numQtdLinhasEnunciado.Name = "numQtdLinhasEnunciado";
            this.numQtdLinhasEnunciado.Size = new System.Drawing.Size(61, 22);
            this.numQtdLinhasEnunciado.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Qtd. Lin. Enunciado:";
            // 
            // numTempoMinReutilizacao
            // 
            this.numTempoMinReutilizacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numTempoMinReutilizacao.Location = new System.Drawing.Point(619, 310);
            this.numTempoMinReutilizacao.Name = "numTempoMinReutilizacao";
            this.numTempoMinReutilizacao.Size = new System.Drawing.Size(61, 22);
            this.numTempoMinReutilizacao.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tempo Mín. Reutilização:";
            // 
            // numTempoResposta
            // 
            this.numTempoResposta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numTempoResposta.Location = new System.Drawing.Point(369, 310);
            this.numTempoResposta.Name = "numTempoResposta";
            this.numTempoResposta.Size = new System.Drawing.Size(61, 22);
            this.numTempoResposta.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tempo de Resposta:";
            // 
            // numComplexidade
            // 
            this.numComplexidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numComplexidade.Location = new System.Drawing.Point(149, 310);
            this.numComplexidade.Name = "numComplexidade";
            this.numComplexidade.Size = new System.Drawing.Size(61, 22);
            this.numComplexidade.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Complexidade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Enunciado:";
            // 
            // rchEnunciado
            // 
            this.rchEnunciado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rchEnunciado.Location = new System.Drawing.Point(9, 35);
            this.rchEnunciado.Name = "rchEnunciado";
            this.rchEnunciado.Size = new System.Drawing.Size(672, 265);
            this.rchEnunciado.TabIndex = 0;
            this.rchEnunciado.Text = "";
            // 
            // tabQuestaoImagem
            // 
            this.tabQuestaoImagem.Controls.Add(this.panel1);
            this.tabQuestaoImagem.Location = new System.Drawing.Point(4, 25);
            this.tabQuestaoImagem.Name = "tabQuestaoImagem";
            this.tabQuestaoImagem.Size = new System.Drawing.Size(694, 379);
            this.tabQuestaoImagem.TabIndex = 3;
            this.tabQuestaoImagem.Text = "Imagem";
            this.tabQuestaoImagem.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRemoverImagemQuestao);
            this.panel1.Controls.Add(this.btnAddImagemQuestao);
            this.panel1.Controls.Add(this.picImagemQuestao);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 373);
            this.panel1.TabIndex = 12;
            // 
            // btnRemoverImagemQuestao
            // 
            this.btnRemoverImagemQuestao.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRemoverImagemQuestao.Location = new System.Drawing.Point(580, 196);
            this.btnRemoverImagemQuestao.Name = "btnRemoverImagemQuestao";
            this.btnRemoverImagemQuestao.Size = new System.Drawing.Size(91, 36);
            this.btnRemoverImagemQuestao.TabIndex = 6;
            this.btnRemoverImagemQuestao.Text = "Remover";
            this.btnRemoverImagemQuestao.UseVisualStyleBackColor = true;
            this.btnRemoverImagemQuestao.Click += new System.EventHandler(this.btnRemoverImagemQuestao_Click);
            // 
            // btnAddImagemQuestao
            // 
            this.btnAddImagemQuestao.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddImagemQuestao.Location = new System.Drawing.Point(580, 138);
            this.btnAddImagemQuestao.Name = "btnAddImagemQuestao";
            this.btnAddImagemQuestao.Size = new System.Drawing.Size(91, 36);
            this.btnAddImagemQuestao.TabIndex = 5;
            this.btnAddImagemQuestao.Text = "Adicionar";
            this.btnAddImagemQuestao.UseVisualStyleBackColor = true;
            this.btnAddImagemQuestao.Click += new System.EventHandler(this.btnAddImagemQuestao_Click);
            // 
            // picImagemQuestao
            // 
            this.picImagemQuestao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImagemQuestao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImagemQuestao.Location = new System.Drawing.Point(-1, -1);
            this.picImagemQuestao.Name = "picImagemQuestao";
            this.picImagemQuestao.Size = new System.Drawing.Size(566, 373);
            this.picImagemQuestao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImagemQuestao.TabIndex = 4;
            this.picImagemQuestao.TabStop = false;
            // 
            // tabQuestaoListaSelecao
            // 
            this.tabQuestaoListaSelecao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabQuestaoListaSelecao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabQuestaoListaSelecao.Controls.Add(this.dgvListaSelecao);
            this.tabQuestaoListaSelecao.Location = new System.Drawing.Point(4, 25);
            this.tabQuestaoListaSelecao.Name = "tabQuestaoListaSelecao";
            this.tabQuestaoListaSelecao.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuestaoListaSelecao.Size = new System.Drawing.Size(694, 379);
            this.tabQuestaoListaSelecao.TabIndex = 1;
            this.tabQuestaoListaSelecao.Text = "Lista Seleção";
            // 
            // dgvListaSelecao
            // 
            this.dgvListaSelecao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaSelecao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaSelecao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ListaSelecaoID,
            this.ListaSelecaoDescricao,
            this.ListaSelecaoQtdLinhas});
            this.dgvListaSelecao.Location = new System.Drawing.Point(7, 7);
            this.dgvListaSelecao.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListaSelecao.MultiSelect = false;
            this.dgvListaSelecao.Name = "dgvListaSelecao";
            this.dgvListaSelecao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvListaSelecao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaSelecao.Size = new System.Drawing.Size(678, 363);
            this.dgvListaSelecao.TabIndex = 1;
            this.dgvListaSelecao.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaSelecao_CellValueChanged);
            this.dgvListaSelecao.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvListaSelecao_UserDeletedRow);
            // 
            // ListaSelecaoID
            // 
            this.ListaSelecaoID.HeaderText = "ID";
            this.ListaSelecaoID.Name = "ListaSelecaoID";
            this.ListaSelecaoID.Visible = false;
            // 
            // ListaSelecaoDescricao
            // 
            this.ListaSelecaoDescricao.HeaderText = "Descrição";
            this.ListaSelecaoDescricao.MaxInputLength = 100;
            this.ListaSelecaoDescricao.Name = "ListaSelecaoDescricao";
            this.ListaSelecaoDescricao.Width = 300;
            // 
            // ListaSelecaoQtdLinhas
            // 
            this.ListaSelecaoQtdLinhas.HeaderText = "Qtd. Linhas";
            this.ListaSelecaoQtdLinhas.MaxInputLength = 2;
            this.ListaSelecaoQtdLinhas.Name = "ListaSelecaoQtdLinhas";
            this.ListaSelecaoQtdLinhas.Width = 60;
            // 
            // tabQuestaoListaAssociacao
            // 
            this.tabQuestaoListaAssociacao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabQuestaoListaAssociacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabQuestaoListaAssociacao.Controls.Add(this.dgvListaAssociacao);
            this.tabQuestaoListaAssociacao.Location = new System.Drawing.Point(4, 25);
            this.tabQuestaoListaAssociacao.Name = "tabQuestaoListaAssociacao";
            this.tabQuestaoListaAssociacao.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuestaoListaAssociacao.Size = new System.Drawing.Size(694, 379);
            this.tabQuestaoListaAssociacao.TabIndex = 2;
            this.tabQuestaoListaAssociacao.Text = "Lista de Associação";
            // 
            // dgvListaAssociacao
            // 
            this.dgvListaAssociacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaAssociacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaAssociacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ListaAssociacaoID,
            this.ListaAssociacaoCodigo,
            this.ListaAssociacaoDescricao,
            this.ListaAssociacaoImagem,
            this.ListaAssociacaoQtdLinhas});
            this.dgvListaAssociacao.Location = new System.Drawing.Point(7, 7);
            this.dgvListaAssociacao.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListaAssociacao.MultiSelect = false;
            this.dgvListaAssociacao.Name = "dgvListaAssociacao";
            this.dgvListaAssociacao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvListaAssociacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaAssociacao.Size = new System.Drawing.Size(678, 363);
            this.dgvListaAssociacao.TabIndex = 2;
            this.dgvListaAssociacao.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaAssociacao_CellValueChanged);
            this.dgvListaAssociacao.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvListaAssociacao_UserDeletedRow);
            // 
            // ListaAssociacaoID
            // 
            this.ListaAssociacaoID.HeaderText = "ID";
            this.ListaAssociacaoID.Name = "ListaAssociacaoID";
            this.ListaAssociacaoID.Visible = false;
            // 
            // ListaAssociacaoCodigo
            // 
            this.ListaAssociacaoCodigo.HeaderText = "Cód.";
            this.ListaAssociacaoCodigo.MaxInputLength = 2;
            this.ListaAssociacaoCodigo.Name = "ListaAssociacaoCodigo";
            this.ListaAssociacaoCodigo.Width = 40;
            // 
            // ListaAssociacaoDescricao
            // 
            this.ListaAssociacaoDescricao.HeaderText = "Descrição";
            this.ListaAssociacaoDescricao.MaxInputLength = 100;
            this.ListaAssociacaoDescricao.Name = "ListaAssociacaoDescricao";
            this.ListaAssociacaoDescricao.Width = 300;
            // 
            // ListaAssociacaoImagem
            // 
            this.ListaAssociacaoImagem.ContextMenuStrip = this.contextMenuImagem;
            this.ListaAssociacaoImagem.HeaderText = "Imagem";
            this.ListaAssociacaoImagem.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ListaAssociacaoImagem.Name = "ListaAssociacaoImagem";
            // 
            // contextMenuImagem
            // 
            this.contextMenuImagem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuImagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuListaAssociacaoImagemAdd,
            this.menuListaAssociacaoImagemRemover});
            this.contextMenuImagem.Name = "contextMenuImagem";
            this.contextMenuImagem.Size = new System.Drawing.Size(208, 56);
            this.contextMenuImagem.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuImagem_Opening);
            // 
            // menuListaAssociacaoImagemAdd
            // 
            this.menuListaAssociacaoImagemAdd.Name = "menuListaAssociacaoImagemAdd";
            this.menuListaAssociacaoImagemAdd.Size = new System.Drawing.Size(207, 26);
            this.menuListaAssociacaoImagemAdd.Text = "Adicionar imagem";
            this.menuListaAssociacaoImagemAdd.Click += new System.EventHandler(this.menuListaAssociacaoImagemAdd_Click);
            // 
            // menuListaAssociacaoImagemRemover
            // 
            this.menuListaAssociacaoImagemRemover.Name = "menuListaAssociacaoImagemRemover";
            this.menuListaAssociacaoImagemRemover.Size = new System.Drawing.Size(207, 26);
            this.menuListaAssociacaoImagemRemover.Text = "Remover imagem";
            this.menuListaAssociacaoImagemRemover.Click += new System.EventHandler(this.menuListaAssociacaoImagemRemover_Click);
            // 
            // ListaAssociacaoQtdLinhas
            // 
            this.ListaAssociacaoQtdLinhas.HeaderText = "Qtd. Linhas";
            this.ListaAssociacaoQtdLinhas.MaxInputLength = 2;
            this.ListaAssociacaoQtdLinhas.Name = "ListaAssociacaoQtdLinhas";
            this.ListaAssociacaoQtdLinhas.Width = 60;
            // 
            // FormQuestao
            // 
            this.AcceptButton = this.btnGravar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(723, 590);
            this.Controls.Add(this.tabControlQuestao);
            this.Controls.Add(this.cboTipoQuestao);
            this.Controls.Add(this.cboDisciplina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(741, 637);
            this.Name = "FormQuestao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Questao";
            this.Activated += new System.EventHandler(this.FormQuestao_Activated);
            this.Load += new System.EventHandler(this.FormQuestao_Load);
            this.tabControlQuestao.ResumeLayout(false);
            this.tabQuestaoConfiguracao.ResumeLayout(false);
            this.tabQuestaoConfiguracao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdLinhasResposta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdLinhasEnunciado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempoMinReutilizacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempoResposta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numComplexidade)).EndInit();
            this.tabQuestaoImagem.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImagemQuestao)).EndInit();
            this.tabQuestaoListaSelecao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSelecao)).EndInit();
            this.tabQuestaoListaAssociacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAssociacao)).EndInit();
            this.contextMenuImagem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDisciplina;
        private System.Windows.Forms.ComboBox cboTipoQuestao;
        private System.Windows.Forms.TabControl tabControlQuestao;
        private System.Windows.Forms.TabPage tabQuestaoConfiguracao;
        private System.Windows.Forms.TabPage tabQuestaoListaSelecao;
        private System.Windows.Forms.TabPage tabQuestaoListaAssociacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rchEnunciado;
        private System.Windows.Forms.NumericUpDown numTempoResposta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numComplexidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numTempoMinReutilizacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numQtdLinhasResposta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numQtdLinhasEnunciado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSequenciaImpressao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvListaSelecao;
        private System.Windows.Forms.DataGridView dgvListaAssociacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListaSelecaoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListaSelecaoDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListaSelecaoQtdLinhas;
        private System.Windows.Forms.TabPage tabQuestaoImagem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoverImagemQuestao;
        private System.Windows.Forms.Button btnAddImagemQuestao;
        private System.Windows.Forms.PictureBox picImagemQuestao;
        private System.Windows.Forms.ContextMenuStrip contextMenuImagem;
        private System.Windows.Forms.ToolStripMenuItem menuListaAssociacaoImagemAdd;
        private System.Windows.Forms.ToolStripMenuItem menuListaAssociacaoImagemRemover;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListaAssociacaoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListaAssociacaoCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListaAssociacaoDescricao;
        private System.Windows.Forms.DataGridViewImageColumn ListaAssociacaoImagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListaAssociacaoQtdLinhas;
    }
}