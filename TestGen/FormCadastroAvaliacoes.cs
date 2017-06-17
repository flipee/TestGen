using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormCadastroAvaliacoes : Form
    {
        private bool inLoad = false;
        public FormCadastroAvaliacoes()
        {
            InitializeComponent();
        }

        private void FormCadastroAvaliacoes_Load(object sender, EventArgs e)
        {
            lstAvaliacoes.View = View.Details;
            lstAvaliacoes.FullRowSelect = true;
            lstAvaliacoes.MultiSelect = false;
            lstAvaliacoes.HideSelection = false;

            lstAvaliacoes.Columns.Add("ID");
            lstAvaliacoes.Columns.Add("Código");
            lstAvaliacoes.Columns.Add("Descrição");
            lstAvaliacoes.Columns.Add("Data Geração");
            lstAvaliacoes.Columns.Add("Qtd. Questões");

            lstAvaliacoes.Columns[0].Width = 60;
            lstAvaliacoes.Columns[1].Width = 120;
            lstAvaliacoes.Columns[2].Width = 400;
            lstAvaliacoes.Columns[3].Width = 120;
            lstAvaliacoes.Columns[4].Width = 120;

        }
        private void FormCadastroAvaliacoes_Activated(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Tag = true;

                if (!CarregarDados())
                    this.Close();
            }

        }

        private void lstAvaliacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }
        private void lstAvaliacoes_DoubleClick(object sender, EventArgs e)
        {
            if (lstAvaliacoes.SelectedItems.Count > 0)
                Visualizar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Visualizar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void cboDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inLoad)
            {
                ExecutaPesquisa();
                HabilitaBotoes();
            }
        }

        private void cboDisciplina_TextChanged(object sender, EventArgs e)
        {
            if (!inLoad)
            {
                lstAvaliacoes.BeginUpdate();
                lstAvaliacoes.Items.Clear();
                lstAvaliacoes.EndUpdate();

                HabilitaBotoes();
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            Gerar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "Planilhas Excel|*.xls";
            saveFileDlg.Title = "Salvar planilha excel";

            if (saveFileDlg.ShowDialog() == DialogResult.OK && !saveFileDlg.FileName.Equals(""))
            {
                Exportar(saveFileDlg.FileName);
            }
        }

        private void HabilitaBotoes()
        {
            bool itemselecionado = lstAvaliacoes.SelectedItems.Count > 0;

            btnExportar.Enabled = lstAvaliacoes.Items.Count > 0;

            btnPesquisar.Enabled = cboDisciplina.SelectedIndex >= 0;
            btnGerar.Enabled = cboDisciplina.SelectedIndex >= 0;

            btnVisualizar.Enabled = itemselecionado;
            btnExcluir.Enabled = itemselecionado;
        }
        private void Pesquisar()
        {
            FormPesquisar frmPesq = new FormPesquisar();

            TipoDaPesquisa tipopesquisa = TipoDaPesquisa.Nenhum;
            String pesquisa = "";

            frmPesq.SetEventPesquisa(new EventHandler<PesquisaEventArgs>(delegate (Object o, PesquisaEventArgs a)
                {
                    tipopesquisa = a.TipoPesquisa;
                    pesquisa = a.Pesquisa;
                }));

            frmPesq.ShowDialog(this);

            switch (tipopesquisa)
            {
                case TipoDaPesquisa.PorCodigo:
                    ExecutaPesquisa(pesquisa, null);
                    break;
                case TipoDaPesquisa.PorNome:
                    ExecutaPesquisa(null, pesquisa);
                    break;
                case TipoDaPesquisa.Todos:
                    ExecutaPesquisa();
                    break;
            }
        }
        private void ExecutaPesquisa()
        {
            ExecutaPesquisa(null, null);
        }
        private void ExecutaPesquisa(string codigo, string descricao)
        {
            Cursor.Current = Cursors.WaitCursor;

            int idDisciplina = GetIdItemCombo(cboDisciplina);

            Expression<Func<Avaliacao, bool>> expression = null;

            if (codigo != null && !codigo.Equals(""))
            {
                if (idDisciplina == 0)
                    expression = x => x.Codigo.Contains(codigo);
                else
                    expression = x => x.IdDisciplina == idDisciplina && x.Codigo.Contains(codigo);
            }

            if (descricao != null && !descricao.Equals(""))
            {
                if (idDisciplina == 0)
                    expression = x => x.Descricao.Contains(descricao);
                else
                    expression = x => x.IdDisciplina == idDisciplina && x.Descricao.Contains(descricao);
            }


            List<Avaliacao> lista;

            if (expression != null)
                lista = DBControl.Table<Avaliacao>.Pesquisar(expression);
            else
            {
                if (idDisciplina == 0)
                    lista = DBControl.Table<Avaliacao>.Pesquisar();
                else
                    lista = DBControl.Table<Avaliacao>.Pesquisar(x => x.IdDisciplina == idDisciplina);
            }

            lstAvaliacoes.BeginUpdate();

            lstAvaliacoes.Items.Clear();

            if (lista != null)
            {
                ListViewItem[] items = new ListViewItem[lista.Count];

                int index = 0;

                foreach (Avaliacao Avaliacao in lista)
                {
                    IncluirNovoItem(items, index++, Avaliacao);
                }

                lstAvaliacoes.Items.AddRange(items);
            }

            lstAvaliacoes.EndUpdate();

            HabilitaBotoes();

            Cursor.Current = Cursors.Default;
        }

        private void IncluirNovoItem(ListViewItem[] items, int index, Avaliacao Avaliacao)
        {
            ListViewItem item = new ListViewItem(Avaliacao.Id.ToString());
            item.Tag = Avaliacao.Id;

            item.SubItems.Add(Avaliacao.Codigo.ToString());
            item.SubItems.Add(Avaliacao.Descricao.ToString());

            item.SubItems.Add(Avaliacao.DtGeracao.ToShortDateString());
            item.SubItems.Add(Avaliacao.QtdQuestoes.ToString());

            items[index] = item;
        }
        private void AtualizaItemSelecionado(Avaliacao Avaliacao)
        {
            ListViewItem item = lstAvaliacoes.SelectedItems[0];

            item.SubItems.Clear();

            item.Tag = Avaliacao.Id;
            item.Text = Avaliacao.Id.ToString();
            item.SubItems.Add(Avaliacao.Codigo.ToString());
            item.SubItems.Add(Avaliacao.Descricao.ToString());
            item.SubItems.Add(Avaliacao.DtGeracao.ToShortDateString());
            item.SubItems.Add(Avaliacao.QtdQuestoes.ToString());
        }

        private void Visualizar()
        {
            FormAvaliacao frmAvaliacao = new FormAvaliacao();

            frmAvaliacao.SetOperacao(TipoOperacaoCadastro.Visualizar, GetIdItemSelecionado(lstAvaliacoes));

            frmAvaliacao.ShowDialog(this);
        }
        private void Gerar()
        {
            FormGerarAvaliacao frmGerarAvaliacao = new FormGerarAvaliacao();

            Avaliacao avaliacao = null;

            frmGerarAvaliacao.SetParameters(GetIdItemCombo(cboDisciplina));

            frmGerarAvaliacao.SetEventRetorno(new EventHandler<Avaliacao>(delegate (Object o, Avaliacao a)
            {
                avaliacao = a;
            }));

            frmGerarAvaliacao.ShowDialog(this);

            if (avaliacao != null)
            {
                lstAvaliacoes.BeginUpdate();
                ListViewItem[] items = new ListViewItem[1];

                IncluirNovoItem(items, 0, avaliacao);

                lstAvaliacoes.Items.AddRange(items);

                lstAvaliacoes.EndUpdate();
            }

        }

        private void Excluir()
        {
            FormAvaliacao frmAvaliacao = new FormAvaliacao();

            Avaliacao avaliacao = null;

            frmAvaliacao.SetOperacao(TipoOperacaoCadastro.Excluir, GetIdItemSelecionado(lstAvaliacoes));

            frmAvaliacao.SetEventRetorno(new EventHandler<Avaliacao>(delegate (Object o, Avaliacao a)
                            {
                                avaliacao = a;
                            }));

            frmAvaliacao.ShowDialog(this);

            if (avaliacao != null)
            {
                RemoveItemSelecionado(lstAvaliacoes);
            }
        }

        private bool CarregarDados()
        {
            inLoad = true;

            bool ret = CarregarCombo<Disciplina>(cboDisciplina);

            inLoad = false;

            if (ret)
                ExecutaPesquisa();

            return ret;
        }

        private void Exportar(string arquivo)
        {
            bool ret = false;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Name = "Avaliações";

                int row = ExcelDefCabecalho(xlWorkSheet);

                row = ExcelGravaDados(xlWorkSheet, row);

                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[row, 20]].EntireColumn.AutoFit();

                xlWorkSheet.Range[xlWorkSheet.Cells[1, 10], xlWorkSheet.Cells[1, 19]].Columns.ColumnWidth = 6;
                xlWorkSheet.Cells[1, 20].Columns.ColumnWidth = 50;

                xlApp.DisplayAlerts = false;

                xlWorkBook.SaveAs(arquivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                                  Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();

                liberarObjetos(xlWorkSheet);
                liberarObjetos(xlWorkBook);
                liberarObjetos(xlApp);

                ret = Mensagem.ShowPerguntaSimNao(this,"O arquivo Excel foi criado com sucesso com o nome [" + arquivo + "]!\r\nDeseja abri-lo agora?") == DialogResult.Yes;
            }
            catch (Exception ex)
            {
                Mensagem.ShowErro("Erro ao cirar o arquivo Excel!", ex);
            }

            Cursor.Current = Cursors.Default;

            if (ret)
                System.Diagnostics.Process.Start(arquivo);
        }

        private int ExcelDefCabecalho(Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet)
        {
            int row = 1;

            xlWorkSheet.Cells[row, 1] = "Cadastro da Avaliação";
            xlWorkSheet.Range[xlWorkSheet.Cells[row, 1], xlWorkSheet.Cells[row, 3]].Merge();

            xlWorkSheet.Cells[row, 4] = "Totais";
            xlWorkSheet.Range[xlWorkSheet.Cells[row, 4], xlWorkSheet.Cells[row, 5]].Merge();

            xlWorkSheet.Cells[row, 6] = "Quantidade Total de Questões por Tipo";
            xlWorkSheet.Range[xlWorkSheet.Cells[row, 6], xlWorkSheet.Cells[row, 9]].Merge();

            xlWorkSheet.Cells[row, 10] = "Quantidade Total de Questões por Complexidade";
            xlWorkSheet.Range[xlWorkSheet.Cells[row, 10], xlWorkSheet.Cells[row, 19]].Merge();

            row++;

            string[] headers = new string[] { "ID Avaliação", "Disciplina", "Data de Geração", "Qtd.Questões", "Tempo Prev.Total", "Discursiva", "Esc.Simples","Múltipla Esc.", "Esc.Lista de Assoc.", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Lista Ordenada de Questões" };

            xlWorkSheet.Range[xlWorkSheet.Cells[row, 1], xlWorkSheet.Cells[row, headers.Length]].Value = headers;

            xlWorkSheet.Range[xlWorkSheet.Cells[1, 20], xlWorkSheet.Cells[2, 20]].Merge();

            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[2, 20]].Font.Bold = true;

            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[2, 20]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[2, 20]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[2, 20]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            AllBorders(xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[2, 20]].Borders);

            return ++row;
        }

        private int ExcelGravaDados(Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet, int row)
        {
            bool ret = true;

            Avaliacao avaliacao = null;
            Disciplina disciplina = null;
            List<AvaliacaoQuestao> avaliacaoQuestoes = null;

            List<int> listQuestoes;

            StringBuilder sb;

            object[] dados=null;

            int[] qtdTotTipoQuestao;

            int[] qtdTotComplex;

            int quantidadeQuestoes;
            int tempoTotalPrevisto;
            int qtdLinhasUtilizadas;

            foreach (ListViewItem item in lstAvaliacoes.Items)
            {
                qtdTotTipoQuestao = new int[] { 0, 0, 0, 0 };

                qtdTotComplex = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                quantidadeQuestoes = 0;
                tempoTotalPrevisto = 0;
                qtdLinhasUtilizadas = 0;

                listQuestoes = new List<int>();
                sb = new StringBuilder();

                avaliacao = DBControl.Table<Avaliacao>.Ler((int)item.Tag);

                ret = avaliacao != null && avaliacao.Id!=0;

                if (ret)
                {
                    disciplina = DBControl.Table<Disciplina>.Ler(avaliacao.IdDisciplina);

                    ret = disciplina != null && disciplina.Id != 0;
                }

                if (ret)
                {
                    avaliacaoQuestoes = DBControl.Table<AvaliacaoQuestao>.Pesquisar(x => x.IdAvaliacao == avaliacao.Id);

                    if (avaliacaoQuestoes != null && avaliacaoQuestoes.Count > 0)
                    {
                        Questao questao = null;

                        foreach (AvaliacaoQuestao aq in avaliacaoQuestoes)
                        {
                            listQuestoes.Add(aq.IdQuestao);

                            questao = DBControl.Table<Questao>.Ler(aq.IdQuestao);

                            List<QuestaoItemEscolha> listaQE = DBControl.Table<QuestaoItemEscolha>.Pesquisar(x => x.IdQuestao == aq.IdQuestao);
                            List<QuestaoItemAssociacao> listaQA = DBControl.Table<QuestaoItemAssociacao>.Pesquisar(x => x.IdQuestao == aq.IdQuestao);

                            qtdTotTipoQuestao[(int)questao.TipoQuestao - 1]++;
                            qtdTotComplex[questao.Complexidade - 1]++;
                            quantidadeQuestoes++;
                            tempoTotalPrevisto += questao.TempoResposta;

                            qtdLinhasUtilizadas += questao.QtdLinhasEnunciado;

                            if (questao.TipoQuestao == TipoDeQuestao.Discursiva)
                                qtdLinhasUtilizadas += questao.QtdLinhasResposta;
                            else
                            {
                                foreach (QuestaoItemEscolha qe in listaQE)
                                    qtdLinhasUtilizadas += qe.QtdLinhasOcupadas;

                                foreach (QuestaoItemAssociacao qa in listaQA)
                                    qtdLinhasUtilizadas += qa.QtdLinhasOcupadas;
                            }
                        }
                    }

                    listQuestoes.Sort();

                    foreach (int value in listQuestoes)
                        sb.Append("|").Append(value.ToString());

                    dados = new object[] { avaliacao.Id.ToString(), disciplina.Nome, avaliacao.DtGeracao,
                                           quantidadeQuestoes, tempoTotalPrevisto,
                                           qtdTotTipoQuestao[(int)TipoDeQuestao.Discursiva - 1],
                                           qtdTotTipoQuestao[(int)TipoDeQuestao.EscolhaSimples - 1],
                                           qtdTotTipoQuestao[(int)TipoDeQuestao.MultiplaEscolha - 1],
                                           qtdTotTipoQuestao[(int)TipoDeQuestao.ListaDeAssociacao - 1],
                                           qtdTotComplex[0], qtdTotComplex[1], qtdTotComplex[2], qtdTotComplex[3],
                                           qtdTotComplex[4], qtdTotComplex[5], qtdTotComplex[6], qtdTotComplex[7],
                                           qtdTotComplex[8], qtdTotComplex[9], sb.ToString().Substring(1).Replace("|",", ") };
                }

                if (ret)
                {
                    xlWorkSheet.Range[xlWorkSheet.Cells[row, 1], xlWorkSheet.Cells[row, dados.Length]].Value = dados;
                    row++;
                }
            }

            return row;
        }

        private void liberarObjetos(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;

                Mensagem.ShowErro("Ocorreu um erro durante a liberação de objetos!",ex);
            }
            finally
            {
                GC.Collect();
            }
        }
        private void AllBorders(Microsoft.Office.Interop.Excel.Borders _borders)
        {
            _borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            _borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            _borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            _borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            _borders.Color = Color.Black;
        }

    }
}