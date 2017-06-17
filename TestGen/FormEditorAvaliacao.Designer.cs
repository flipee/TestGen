namespace TestGen
{
    partial class FormEditorAvaliacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditorAvaliacao));
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.svdlg1 = new System.Windows.Forms.SaveFileDialog();
            this.prntdlg1 = new System.Windows.Forms.PrintDialog();
            this.prntdoc1 = new System.Drawing.Printing.PrintDocument();
            this.prntprvdlg1 = new System.Windows.Forms.PrintPreviewDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalvar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVisualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNegrito = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItalico = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSublinhado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlteraFonte = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlinharEsquerda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlinhaDireita = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlinharCentro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuConfiguracoesImpressora = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVisualizarImpressão = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtxtb1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripAbrir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripCopiar = new System.Windows.Forms.ToolStripButton();
            this.toolStripColar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripNegrito = new System.Windows.Forms.ToolStripButton();
            this.toolStripItalico = new System.Windows.Forms.ToolStripButton();
            this.toolStripSublinhado = new System.Windows.Forms.ToolStripButton();
            this.toolStripFonte = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripConfigImpressora = new System.Windows.Forms.ToolStripButton();
            this.toolStripImprimir2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripVisualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSair = new System.Windows.Forms.ToolStripButton();
            this.fontdlg1 = new System.Windows.Forms.FontDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofd1
            // 
            this.ofd1.FileName = "openFileDialog1";
            // 
            // prntdlg1
            // 
            this.prntdlg1.UseEXDialog = true;
            // 
            // prntdoc1
            // 
            this.prntdoc1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prntdoc1_PrintPage);
            // 
            // prntprvdlg1
            // 
            this.prntprvdlg1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prntprvdlg1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prntprvdlg1.ClientSize = new System.Drawing.Size(400, 300);
            this.prntprvdlg1.Enabled = true;
            this.prntprvdlg1.Icon = ((System.Drawing.Icon)(resources.GetObject("prntprvdlg1.Icon")));
            this.prntprvdlg1.Name = "prntprvdlg1";
            this.prntprvdlg1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.mnuVisualizar,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNovo,
            this.mnuAbrir,
            this.mnuSalvar,
            this.mnuCopiar,
            this.mnuColar,
            this.toolStripMenuItem2,
            this.toolStripMenuItem5,
            this.toolStripMenuItem1,
            this.mnuSair});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // mnuNovo
            // 
            this.mnuNovo.Name = "mnuNovo";
            this.mnuNovo.Size = new System.Drawing.Size(147, 22);
            this.mnuNovo.Text = "&Novo";
            this.mnuNovo.Click += new System.EventHandler(this.mnuNovo_Click);
            // 
            // mnuAbrir
            // 
            this.mnuAbrir.Name = "mnuAbrir";
            this.mnuAbrir.Size = new System.Drawing.Size(147, 22);
            this.mnuAbrir.Text = "&Abrir Texto";
            this.mnuAbrir.Click += new System.EventHandler(this.mnuAbrir_Click);
            // 
            // mnuSalvar
            // 
            this.mnuSalvar.Name = "mnuSalvar";
            this.mnuSalvar.Size = new System.Drawing.Size(147, 22);
            this.mnuSalvar.Text = "&Salvar Texto";
            this.mnuSalvar.Click += new System.EventHandler(this.mnuSalvar_Click);
            // 
            // mnuCopiar
            // 
            this.mnuCopiar.Name = "mnuCopiar";
            this.mnuCopiar.Size = new System.Drawing.Size(147, 22);
            this.mnuCopiar.Text = "Co&piar";
            this.mnuCopiar.Click += new System.EventHandler(this.mnuCopiar_Click);
            // 
            // mnuColar
            // 
            this.mnuColar.Name = "mnuColar";
            this.mnuColar.Size = new System.Drawing.Size(147, 22);
            this.mnuColar.Text = "Co&lar";
            this.mnuColar.Click += new System.EventHandler(this.mnuColar_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem2.Text = "Refazer";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem5.Text = "Desfazer";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
            // 
            // mnuSair
            // 
            this.mnuSair.Name = "mnuSair";
            this.mnuSair.Size = new System.Drawing.Size(147, 22);
            this.mnuSair.Text = "S&air";
            // 
            // mnuVisualizar
            // 
            this.mnuVisualizar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNegrito,
            this.mnuItalico,
            this.mnuSublinhado,
            this.mnuAlteraFonte,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.mnuConfiguracoesImpressora,
            this.menuVisualizarImpressão,
            this.mnuImprimir});
            this.mnuVisualizar.Name = "mnuVisualizar";
            this.mnuVisualizar.Size = new System.Drawing.Size(65, 21);
            this.mnuVisualizar.Text = "Opções";
            // 
            // mnuNegrito
            // 
            this.mnuNegrito.Name = "mnuNegrito";
            this.mnuNegrito.Size = new System.Drawing.Size(225, 22);
            this.mnuNegrito.Text = "&Negrito";
            this.mnuNegrito.Click += new System.EventHandler(this.mnuNegrito_Click);
            // 
            // mnuItalico
            // 
            this.mnuItalico.Name = "mnuItalico";
            this.mnuItalico.Size = new System.Drawing.Size(225, 22);
            this.mnuItalico.Text = "&Itálico";
            this.mnuItalico.Click += new System.EventHandler(this.mnuItalico_Click);
            // 
            // mnuSublinhado
            // 
            this.mnuSublinhado.Name = "mnuSublinhado";
            this.mnuSublinhado.Size = new System.Drawing.Size(225, 22);
            this.mnuSublinhado.Text = "&Sublinhado";
            this.mnuSublinhado.Click += new System.EventHandler(this.mnuSublinhado_Click);
            // 
            // mnuAlteraFonte
            // 
            this.mnuAlteraFonte.Name = "mnuAlteraFonte";
            this.mnuAlteraFonte.Size = new System.Drawing.Size(225, 22);
            this.mnuAlteraFonte.Text = "&Alterar Fonte";
            this.mnuAlteraFonte.Click += new System.EventHandler(this.mnuAlteraFonte_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAlinharEsquerda,
            this.mnuAlinhaDireita,
            this.mnuAlinharCentro});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(225, 22);
            this.toolStripMenuItem3.Text = "Alinhar Texto";
            // 
            // mnuAlinharEsquerda
            // 
            this.mnuAlinharEsquerda.Name = "mnuAlinharEsquerda";
            this.mnuAlinharEsquerda.Size = new System.Drawing.Size(131, 22);
            this.mnuAlinharEsquerda.Text = "Esquerda";
            this.mnuAlinharEsquerda.Click += new System.EventHandler(this.mnuAlinharEsquerda_Click);
            // 
            // mnuAlinhaDireita
            // 
            this.mnuAlinhaDireita.Name = "mnuAlinhaDireita";
            this.mnuAlinhaDireita.Size = new System.Drawing.Size(131, 22);
            this.mnuAlinhaDireita.Text = "Direita";
            this.mnuAlinhaDireita.Click += new System.EventHandler(this.mnuAlinhaDireita_Click);
            // 
            // mnuAlinharCentro
            // 
            this.mnuAlinharCentro.Name = "mnuAlinharCentro";
            this.mnuAlinharCentro.Size = new System.Drawing.Size(131, 22);
            this.mnuAlinharCentro.Text = "Centro";
            this.mnuAlinharCentro.Click += new System.EventHandler(this.mnuAlinharCentro_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(222, 6);
            // 
            // mnuConfiguracoesImpressora
            // 
            this.mnuConfiguracoesImpressora.Name = "mnuConfiguracoesImpressora";
            this.mnuConfiguracoesImpressora.Size = new System.Drawing.Size(225, 22);
            this.mnuConfiguracoesImpressora.Text = "&Configurações Impressão";
            this.mnuConfiguracoesImpressora.Click += new System.EventHandler(this.mnuConfiguracoesImpressora_Click);
            // 
            // menuVisualizarImpressão
            // 
            this.menuVisualizarImpressão.Name = "menuVisualizarImpressão";
            this.menuVisualizarImpressão.Size = new System.Drawing.Size(225, 22);
            this.menuVisualizarImpressão.Text = "&Visualizar Impressão";
            this.menuVisualizarImpressão.Click += new System.EventHandler(this.mnuVisualizarImpressão_Click);
            // 
            // mnuImprimir
            // 
            this.mnuImprimir.Name = "mnuImprimir";
            this.mnuImprimir.Size = new System.Drawing.Size(225, 22);
            this.mnuImprimir.Text = "&Imprimir";
            this.mnuImprimir.Click += new System.EventHandler(this.mnuImprimir_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // rtxtb1
            // 
            this.rtxtb1.AcceptsTab = true;
            this.rtxtb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtb1.Location = new System.Drawing.Point(0, 57);
            this.rtxtb1.Name = "rtxtb1";
            this.rtxtb1.Size = new System.Drawing.Size(881, 577);
            this.rtxtb1.TabIndex = 1;
            this.rtxtb1.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNovo,
            this.toolStripAbrir,
            this.toolStripSalvar,
            this.toolStripCopiar,
            this.toolStripColar,
            this.toolStripSeparator3,
            this.toolStripNegrito,
            this.toolStripItalico,
            this.toolStripSublinhado,
            this.toolStripFonte,
            this.toolStripSeparator1,
            this.toolStripConfigImpressora,
            this.toolStripImprimir2,
            this.toolStripVisualizar,
            this.toolStripSeparator2,
            this.toolStripSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(881, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripNovo
            // 
            this.toolStripNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripNovo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNovo.Image")));
            this.toolStripNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNovo.Name = "toolStripNovo";
            this.toolStripNovo.Size = new System.Drawing.Size(23, 22);
            this.toolStripNovo.Text = "Novo";
            this.toolStripNovo.Click += new System.EventHandler(this.toolStripNovo_Click);
            // 
            // toolStripAbrir
            // 
            this.toolStripAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAbrir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAbrir.Image")));
            this.toolStripAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAbrir.Name = "toolStripAbrir";
            this.toolStripAbrir.Size = new System.Drawing.Size(23, 22);
            this.toolStripAbrir.Text = "Abrir";
            this.toolStripAbrir.Click += new System.EventHandler(this.toolStripAbrir_Click);
            // 
            // toolStripSalvar
            // 
            this.toolStripSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSalvar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSalvar.Image")));
            this.toolStripSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSalvar.Name = "toolStripSalvar";
            this.toolStripSalvar.Size = new System.Drawing.Size(23, 22);
            this.toolStripSalvar.Text = "Salvar";
            this.toolStripSalvar.ToolTipText = "Salvar Texto";
            this.toolStripSalvar.Click += new System.EventHandler(this.toolStripSalvar_Click);
            // 
            // toolStripCopiar
            // 
            this.toolStripCopiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCopiar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCopiar.Image")));
            this.toolStripCopiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCopiar.Name = "toolStripCopiar";
            this.toolStripCopiar.Size = new System.Drawing.Size(23, 22);
            this.toolStripCopiar.Text = "Copiar";
            this.toolStripCopiar.Click += new System.EventHandler(this.toolStripCopiar_Click);
            // 
            // toolStripColar
            // 
            this.toolStripColar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripColar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripColar.Image")));
            this.toolStripColar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColar.Name = "toolStripColar";
            this.toolStripColar.Size = new System.Drawing.Size(23, 22);
            this.toolStripColar.Text = "Colar";
            this.toolStripColar.Click += new System.EventHandler(this.toolStripColar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripNegrito
            // 
            this.toolStripNegrito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripNegrito.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNegrito.Image")));
            this.toolStripNegrito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNegrito.Name = "toolStripNegrito";
            this.toolStripNegrito.Size = new System.Drawing.Size(23, 22);
            this.toolStripNegrito.Text = "Negrito";
            this.toolStripNegrito.Click += new System.EventHandler(this.toolStripNegrito_Click);
            // 
            // toolStripItalico
            // 
            this.toolStripItalico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripItalico.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItalico.Image")));
            this.toolStripItalico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItalico.Name = "toolStripItalico";
            this.toolStripItalico.Size = new System.Drawing.Size(23, 22);
            this.toolStripItalico.Text = "Itálico";
            this.toolStripItalico.Click += new System.EventHandler(this.toolStripItalico_Click);
            // 
            // toolStripSublinhado
            // 
            this.toolStripSublinhado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSublinhado.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSublinhado.Image")));
            this.toolStripSublinhado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSublinhado.Name = "toolStripSublinhado";
            this.toolStripSublinhado.Size = new System.Drawing.Size(23, 22);
            this.toolStripSublinhado.Text = "Sublinhado";
            this.toolStripSublinhado.Click += new System.EventHandler(this.toolStripSublinhado_Click);
            // 
            // toolStripFonte
            // 
            this.toolStripFonte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFonte.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFonte.Image")));
            this.toolStripFonte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFonte.Name = "toolStripFonte";
            this.toolStripFonte.Size = new System.Drawing.Size(23, 22);
            this.toolStripFonte.Text = "Alterar Fonte";
            this.toolStripFonte.Click += new System.EventHandler(this.toolStripFonte_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripConfigImpressora
            // 
            this.toolStripConfigImpressora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripConfigImpressora.Image = ((System.Drawing.Image)(resources.GetObject("toolStripConfigImpressora.Image")));
            this.toolStripConfigImpressora.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConfigImpressora.Name = "toolStripConfigImpressora";
            this.toolStripConfigImpressora.Size = new System.Drawing.Size(23, 22);
            this.toolStripConfigImpressora.Text = "Configurações Impressora";
            this.toolStripConfigImpressora.Click += new System.EventHandler(this.toolStripConfigImpressora_Click);
            // 
            // toolStripImprimir2
            // 
            this.toolStripImprimir2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripImprimir2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripImprimir2.Image")));
            this.toolStripImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripImprimir2.Name = "toolStripImprimir2";
            this.toolStripImprimir2.Size = new System.Drawing.Size(23, 22);
            this.toolStripImprimir2.Text = "Imprimir";
            this.toolStripImprimir2.Click += new System.EventHandler(this.toolStripImprimir2_Click);
            // 
            // toolStripVisualizar
            // 
            this.toolStripVisualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripVisualizar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripVisualizar.Image")));
            this.toolStripVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripVisualizar.Name = "toolStripVisualizar";
            this.toolStripVisualizar.Size = new System.Drawing.Size(23, 22);
            this.toolStripVisualizar.Text = "Visualizar Impressão";
            this.toolStripVisualizar.Click += new System.EventHandler(this.toolStripVisualizar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSair
            // 
            this.toolStripSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSair.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSair.Image")));
            this.toolStripSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSair.Name = "toolStripSair";
            this.toolStripSair.Size = new System.Drawing.Size(23, 22);
            this.toolStripSair.Text = "Sair";
            this.toolStripSair.Click += new System.EventHandler(this.toolStripSair_Click);
            // 
            // FormEditorAvaliacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(881, 634);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.rtxtb1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormEditorAvaliacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor Avaliação";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.SaveFileDialog svdlg1;
        private System.Windows.Forms.PrintDialog prntdlg1;
        private System.Drawing.Printing.PrintDocument prntdoc1;
        private System.Windows.Forms.PrintPreviewDialog prntprvdlg1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RichTextBox rtxtb1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuVisualizar;
        private System.Windows.Forms.ToolStripMenuItem mnuAlteraFonte;
        private System.Windows.Forms.ToolStripButton toolStripNovo;
        private System.Windows.Forms.ToolStripButton toolStripAbrir;
        private System.Windows.Forms.FontDialog fontdlg1;
        private System.Windows.Forms.ToolStripButton toolStripSalvar;
        private System.Windows.Forms.ToolStripButton toolStripCopiar;
        private System.Windows.Forms.ToolStripButton toolStripColar;
        private System.Windows.Forms.ToolStripButton toolStripNegrito;
        private System.Windows.Forms.ToolStripButton toolStripItalico;
        private System.Windows.Forms.ToolStripButton toolStripSublinhado;
        private System.Windows.Forms.ToolStripButton toolStripFonte;
        private System.Windows.Forms.ToolStripButton toolStripVisualizar;
        private System.Windows.Forms.ToolStripButton toolStripImprimir;
        private System.Windows.Forms.ToolStripButton toolStripSair;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuNegrito;
        private System.Windows.Forms.ToolStripMenuItem mnuItalico;
        private System.Windows.Forms.ToolStripMenuItem mnuSublinhado;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuVisualizarImpressão;
        private System.Windows.Forms.ToolStripMenuItem mnuImprimir;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNovo;
        private System.Windows.Forms.ToolStripMenuItem mnuAbrir;
        private System.Windows.Forms.ToolStripMenuItem mnuSalvar;
        private System.Windows.Forms.ToolStripMenuItem mnuCopiar;
        private System.Windows.Forms.ToolStripMenuItem mnuColar;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSair;
        private System.Windows.Forms.ToolStripMenuItem mnuConfiguracoesImpressora;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuAlinharEsquerda;
        private System.Windows.Forms.ToolStripMenuItem mnuAlinhaDireita;
        private System.Windows.Forms.ToolStripMenuItem mnuAlinharCentro;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripButton toolStripConfigImpressora;
        private System.Windows.Forms.ToolStripButton toolStripImprimir2;
    }
}

