using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormCadastroQuestoes : Form
    {
        private bool inLoad = false;
        public FormCadastroQuestoes()
        {
            InitializeComponent();
        }

        private void FormCadastroQuestoes_Load(object sender, EventArgs e)
        {
            lstQuestoes.View = View.Details;
            lstQuestoes.FullRowSelect = true;
            lstQuestoes.MultiSelect = false;
            lstQuestoes.HideSelection = false;

            lstQuestoes.Columns.Add("ID");
            lstQuestoes.Columns.Add("Enunciado");

            lstQuestoes.Columns[0].Width = 60;
            lstQuestoes.Columns[1].Width = 1000;
        }
        private void FormCadastroQuestoes_Activated(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Tag = true;

                if (!CarregarDados())
                    this.Close();
            }

        }

        private void lstQuestoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }
        private void lstQuestoes_DoubleClick(object sender, EventArgs e)
        {
            if (lstQuestoes.SelectedItems.Count > 0)
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Incluir();
        }
        private void HabilitaBotoes()
        {
            bool itemselecionado = lstQuestoes.SelectedItems.Count > 0;

            btnPesquisar.Enabled = cboDisciplina.SelectedIndex >= 0;

            btnVisualizar.Enabled = itemselecionado;
            btnAlterar.Enabled = itemselecionado;
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
                case TipoDaPesquisa.PorNome:
                    ExecutaPesquisa(pesquisa);
                    break;
                case TipoDaPesquisa.Todos:
                    ExecutaPesquisa();
                    break;
            }
        }
        private void ExecutaPesquisa()
        {
            ExecutaPesquisa(null);
        }
        private void ExecutaPesquisa(String Enunciado)
        {
            Cursor.Current = Cursors.WaitCursor;

            int idDisciplina = GetIdItemCombo(cboDisciplina);

            Expression<Func<Questao, bool>> expression = null;

            if (Enunciado != null && !Enunciado.Equals(""))
            {
                if (idDisciplina == 0)
                    expression = x => x.Enunciado.Contains(Enunciado);
                else
                    expression = x => x.IdDisciplina==idDisciplina && x.Enunciado.Contains(Enunciado);
            }

            List<Questao> lista;

            if (expression != null)
                lista = DBControl.Table<Questao>.Pesquisar(expression);
            else
            {
                if (idDisciplina == 0)
                    lista = DBControl.Table<Questao>.Pesquisar();
                else
                    lista = DBControl.Table<Questao>.Pesquisar(x => x.IdDisciplina == idDisciplina);
            }

            lstQuestoes.BeginUpdate();

            lstQuestoes.Items.Clear();

            if (lista != null)
            {
                ListViewItem[] items = new ListViewItem[lista.Count];

                int index = 0;

                foreach (Questao Questao in lista)
                {
                    IncluirNovoItem(items,index++,Questao);
                }

                lstQuestoes.Items.AddRange(items);
            }

            lstQuestoes.EndUpdate();

            HabilitaBotoes();

            Cursor.Current = Cursors.Default;
        }

        private void IncluirNovoItem(ListViewItem[] items,int index,Questao Questao)
        {
            ListViewItem item = new ListViewItem(Questao.Id.ToString());
            item.BackColor = Questao.Ativo ? Color.White : Color.LightSalmon;
            item.Tag = Questao.Id;

            item.SubItems.Add(Questao.Enunciado);

            items[index]=item;
        }
        private void AtualizaItemSelecionado(Questao Questao)
        {
            ListViewItem item = lstQuestoes.SelectedItems[0];

            item.SubItems.Clear();

            item.Text = Questao.Id.ToString();
            item.BackColor = Questao.Ativo ? Color.White : Color.LightSalmon;
            item.SubItems.Add(Questao.Enunciado);
        }

        private void Visualizar()
        {
            FormQuestao frmQuestao = new FormQuestao();

            frmQuestao.SetOperacao(TipoOperacaoCadastro.Visualizar, GetIdItemSelecionado(lstQuestoes),0);

            frmQuestao.ShowDialog(this);
        }

        private void Incluir()
        {
            FormQuestao frmQuestao = new FormQuestao();

            Questao questao = null;

            frmQuestao.SetOperacao(TipoOperacaoCadastro.Incluir, 0,GetIdItemCombo(cboDisciplina));

            frmQuestao.SetEventRetorno(new EventHandler<Questao>(delegate (Object o, Questao a)
            {
                questao = a;
            }));

            frmQuestao.ShowDialog(this);

            if (questao != null)
            {
                lstQuestoes.BeginUpdate();
                ListViewItem[] items = new ListViewItem[1];

                IncluirNovoItem(items,0,questao);

                lstQuestoes.Items.AddRange(items);

                lstQuestoes.EndUpdate();
            }

        }
        private void Alterar()
        {
            FormQuestao frmQuestao = new FormQuestao();

            Questao questao = null;

            frmQuestao.SetOperacao(TipoOperacaoCadastro.Alterar, GetIdItemSelecionado(lstQuestoes),0);

            frmQuestao.SetEventRetorno(new EventHandler<Questao>(delegate (Object o, Questao a)
            {
                questao = a;
            }));

            frmQuestao.ShowDialog(this);

            if (questao != null)
            {
                AtualizaItemSelecionado(questao);
            }
        }
        private void Excluir()
        {
            FormQuestao frmQuestao = new FormQuestao();

            Questao questao = null;

            frmQuestao.SetOperacao(TipoOperacaoCadastro.Excluir, GetIdItemSelecionado(lstQuestoes),0);

            frmQuestao.SetEventRetorno(new EventHandler<Questao>(delegate (Object o, Questao a)
                            {
                                questao = a;
                            }));

            frmQuestao.ShowDialog(this);

            if (questao != null)
            {
                RemoveItemSelecionado(lstQuestoes);
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
                lstQuestoes.BeginUpdate();
                lstQuestoes.Items.Clear();
                lstQuestoes.EndUpdate();

                HabilitaBotoes();
            }
        }
    }
}