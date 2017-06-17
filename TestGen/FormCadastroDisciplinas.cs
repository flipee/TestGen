using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormCadastroDisciplinas : Form
    {
        public FormCadastroDisciplinas()
        {
            InitializeComponent();
        }

        private void FormCadastroDisciplinas_Load(object sender, EventArgs e)
        {
            lstDisciplinas.View = View.Details;
            lstDisciplinas.FullRowSelect = true;
            lstDisciplinas.MultiSelect = false;
            lstDisciplinas.HideSelection = false;

            lstDisciplinas.Columns.Add("ID");
            lstDisciplinas.Columns.Add("Código");
            lstDisciplinas.Columns.Add("Nome");

            lstDisciplinas.Columns[0].Width = 60;
            lstDisciplinas.Columns[1].Width = 80;
            lstDisciplinas.Columns[2].Width = 500;
        }
        private void FormCadastroDisciplinas_Activated(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Tag = true;

                ExecutaPesquisa();
            }

        }

        private void lstDisciplinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }
        private void lstDisciplinas_DoubleClick(object sender, EventArgs e)
        {
            if (lstDisciplinas.SelectedItems.Count > 0)
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
            bool itemselecionado = lstDisciplinas.SelectedItems.Count > 0;

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
        private void ExecutaPesquisa(String codigo, String nome)
        {
            Cursor.Current = Cursors.WaitCursor;

            Expression<Func<Disciplina, bool>> expression = null;

            if (codigo != null && !codigo.Equals(""))
            {
                expression = x => x.Codigo.Contains(codigo);
            }

            if (nome != null && !nome.Equals(""))
            {
                expression = x => x.Nome.Contains(nome);
            }

            List<Disciplina> lista;

            if (expression != null)
                lista = DBControl.Table<Disciplina>.Pesquisar(expression);
            else
                lista = DBControl.Table<Disciplina>.Pesquisar();

            lstDisciplinas.BeginUpdate();

            lstDisciplinas.Items.Clear();

            if (lista != null)
            {

                foreach (Disciplina Disciplina in lista)
                {
                    IncluirNovoItem(Disciplina);
                }
            }

            lstDisciplinas.EndUpdate();

            HabilitaBotoes();

            Cursor.Current = Cursors.Default;
        }

        private void IncluirNovoItem(Disciplina Disciplina)
        {
            ListViewItem item = new ListViewItem(Disciplina.Id.ToString());
            item.BackColor = Disciplina.Ativo ? Color.White : Color.LightSalmon;
            item.Tag = Disciplina.Id;

            item.SubItems.Add(Disciplina.Codigo);
            item.SubItems.Add(Disciplina.Nome);

            lstDisciplinas.Items.Add(item);
        }
        private void AtualizaItemSelecionado(Disciplina Disciplina)
        {
            ListViewItem item = lstDisciplinas.SelectedItems[0];

            item.SubItems.Clear();

            item.Text = Disciplina.Id.ToString();
            item.BackColor = Disciplina.Ativo ? Color.White : Color.LightSalmon;
            item.SubItems.Add(Disciplina.Codigo);
            item.SubItems.Add(Disciplina.Nome);
        }

        private void Visualizar()
        {
            FormDisciplina frmDisciplina = new FormDisciplina();

            frmDisciplina.SetOperacao(TipoOperacaoCadastro.Visualizar, GetIdItemSelecionado(lstDisciplinas));

            frmDisciplina.ShowDialog(this);
        }

        private void Incluir()
        {
            FormDisciplina frmDisciplina = new FormDisciplina();

            Disciplina disciplina = null;

            frmDisciplina.SetOperacao(TipoOperacaoCadastro.Incluir, 0);

            frmDisciplina.SetEventRetorno(new EventHandler<Disciplina>(delegate (Object o, Disciplina a)
            {
                disciplina = a;
            }));

            frmDisciplina.ShowDialog(this);

            if (disciplina != null)
            {
                lstDisciplinas.BeginUpdate();

                IncluirNovoItem(disciplina);

                lstDisciplinas.EndUpdate();
            }

        }
        private void Alterar()
        {
            FormDisciplina frmDisciplina = new FormDisciplina();

            Disciplina disciplina = null;

            frmDisciplina.SetOperacao(TipoOperacaoCadastro.Alterar, GetIdItemSelecionado(lstDisciplinas));

            frmDisciplina.SetEventRetorno(new EventHandler<Disciplina>(delegate (Object o, Disciplina a)
            {
                disciplina = a;
            }));

            frmDisciplina.ShowDialog(this);

            if (disciplina != null)
            {
                AtualizaItemSelecionado(disciplina);
            }
        }
        private void Excluir()
        {
            FormDisciplina frmDisciplina = new FormDisciplina();

            Disciplina disciplina = null;

            frmDisciplina.SetOperacao(TipoOperacaoCadastro.Excluir, GetIdItemSelecionado(lstDisciplinas));

            frmDisciplina.SetEventRetorno(new EventHandler<Disciplina>(delegate (Object o, Disciplina a)
                            {
                                disciplina = a;
                            }));

            frmDisciplina.ShowDialog(this);

            if (disciplina != null)
            {
                RemoveItemSelecionado(lstDisciplinas);
            }

        }
    }
}