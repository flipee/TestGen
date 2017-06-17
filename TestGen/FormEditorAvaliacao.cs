﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGen
{
    public partial class FormEditorAvaliacao : Form
    {
        public FormEditorAvaliacao()
        {
            InitializeComponent();
        }

        #region Methods 
            #region Tabs 
             private void AddTab() {
            RichTextBox Body = new RichTextBox();
            Body.Name = "Body";
            Body.Dock = DockStyle.Fill;
            Body.ContextMenuStrip = contextMenuStrip1;
            TabPage NewPage = new TabPage(); TabCount += 1;
            string DocumentText = "Avaliação " + TabCount;
            NewPage.Name = DocumentText;
            NewPage.Text = DocumentText; NewPage.Controls.Add(Body);
            tabControl1.TabPages.Add(NewPage);
                }
             private void RemoveTab() {
            if (tabControl1.TabPages.Count != 1) { tabControl1.TabPages.Remove(tabControl1.SelectedTab); } else { tabControl1.TabPages.Remove(tabControl1.SelectedTab); AddTab(); }


        }
             private void RemoveAllTabs() {
            foreach (TabPage Page in tabControl1.TabPages) { tabControl1.TabPages.Remove(Page); }
            AddTab();

            
        }
             private void RemoveAllTabsButThis() {
            foreach (TabPage Page in tabControl1.TabPages) { if (Page.Name != tabControl1.SelectedTab.Name) { tabControl1.TabPages.Remove(Page); } }


        }
        #endregion
        #region SaveAndOpen 
            private void Save() {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name; saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); saveFileDialog1.Filter = "RTF|*.rtf"; saveFileDialog1.Title = "Save"; if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { if (saveFileDialog1.FileName.Length > 0) { GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText); } }

        }
            private void SaveAs() {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name; saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); saveFileDialog1.Filter = "Text Files|*.txt|VB Files|*.vb|C# Files|*.cs|All Files|*.*"; saveFileDialog1.Title = "Save As"; if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { if (saveFileDialog1.FileName.Length > 0) { GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText); } }


        }
            private void Open() {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); openFileDialog1.Filter = "RTF|*.rtf|Text Files|*.txt|VB Files|*.vb|C# Files|*.cs|All Files|*.*"; if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { if (openFileDialog1.FileName.Length > 9) { GetCurrentDocument.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText); } }

           
        }
        #endregion
        private void GetFontCollection() { InstalledFontCollection InsFonts = new InstalledFontCollection(); foreach (FontFamily item in InsFonts.Families) { toolStripComboBox1.Items.Add(item.Name); } toolStripComboBox1.SelectedIndex = 0; }
        private void PopulateFontSizes() { for (int i = 1; i <= 75; i++) { toolStripComboBox2.Items.Add(i); } toolStripComboBox2.SelectedIndex = 11; }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) { Undo(); }



        private void Undo() { GetCurrentDocument.Undo(); }
        private void Redo() { GetCurrentDocument.Redo(); }
        private void Cut() { GetCurrentDocument.Cut(); }
        private void Copy() { GetCurrentDocument.Copy(); }
        private void Paste() { GetCurrentDocument.Paste(); }
        private void SelectAll() { GetCurrentDocument.SelectAll(); }

       

        #endregion

        private int TabCount = 0;

        #region Properties 
        private RichTextBox GetCurrentDocument { get { return (RichTextBox)tabControl1.SelectedTab.Controls["Body"]; } }


        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Font BoldFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Bold);
            Font RegularFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Bold) {
                GetCurrentDocument.SelectionFont = RegularFont;
            } else {
                GetCurrentDocument.SelectionFont = BoldFont;
            }


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Font ItalicFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Italic);
            Font RegularFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Bold)
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = ItalicFont;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Font UnderlineFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Underline);
            Font RegularFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Bold)
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = UnderlineFont;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Font StrikeoutFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Strikeout);
            Font RegularFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Bold)
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = StrikeoutFont;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToUpper();

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToLower();

           
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints + 2; Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name, NewFontSize, GetCurrentDocument.SelectionFont.Style); GetCurrentDocument.SelectionFont = NewSize;


        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints - 2; Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name, NewFontSize, GetCurrentDocument.SelectionFont.Style); GetCurrentDocument.SelectionFont = NewSize;

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { GetCurrentDocument.SelectionColor = colorDialog1.Color; }

    
        }

        private void HighlightGreen_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectionBackColor = Color.LightGreen;

           


        }

        private void HighlightOrange_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectionBackColor = Color.Orange;

            
        }

        private void HighlightYellow_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectionBackColor = Color.LightYellow;


        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font NewFont = new Font(toolStripComboBox1.SelectedItem.ToString(), GetCurrentDocument.SelectionFont.Size, GetCurrentDocument.SelectionFont.Style); GetCurrentDocument.SelectionFont = NewFont;

        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            float NewSize; float.TryParse(toolStripComboBox2.SelectedItem.ToString(), out NewSize); Font NewFont = new Font(GetCurrentDocument.SelectionFont.Name, NewSize, GetCurrentDocument.SelectionFont.Style); GetCurrentDocument.SelectionFont = NewFont;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetCurrentDocument.Text.Length > 0) { toolStripStatusLabel1.Text = GetCurrentDocument.Text.Length.ToString(); }


        }

        private void fmrEditor_Load(object sender, EventArgs e)
        {
            AddTab(); GetFontCollection(); PopulateFontSizes();

   
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void RemoveTabToolStripButton_Click(object sender, EventArgs e)
        {
            RemoveTab();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllTabs();
        }

        private void closeAllButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllTabsButThis();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
