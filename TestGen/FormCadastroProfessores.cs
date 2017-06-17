using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormCadastroProfessores : Form
    {
        public FormCadastroProfessores()
        {
            InitializeComponent();
        }

        private void FormCadastroProfessores_Load(object sender, EventArgs e)
        {
            lstProfessores.View = View.Details;
            lstProfessores.FullRowSelect = true;
            lstProfessores.MultiSelect = false;
            lstProfessores.HideSelection = false;

            lstProfessores.Columns.Add("ID");
            lstProfessores.Columns.Add("Código");
            lstProfessores.Columns.Add("Nome");

            lstProfessores.Columns[0].Width = 60;
            lstProfessores.Columns[1].Width = 80;
            lstProfessores.Columns[2].Width = 500;
        }
        private void FormCadastroProfessores_Activated(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Tag = true;

                ExecutaPesquisa();
            }

        }

        private void lstProfessores_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }
        private void lstProfessores_DoubleClick(object sender, EventArgs e)
        {
            if (lstProfessores.SelectedItems.Count > 0)
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
            bool itemselecionado = lstProfessores.SelectedItems.Count > 0;

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

            Expression<Func<Professor, bool>> expression = null;

            if (codigo != null && !codigo.Equals(""))
            {
                expression = x => x.Codigo.Contains(codigo);
            }

            if (nome != null && !nome.Equals(""))
            {
                expression = x => x.Nome.Contains(nome);
            }

            List<Professor> lista;

            if (expression != null)
                lista = DBControl.Table<Professor>.Pesquisar(expression);
            else
                lista = DBControl.Table<Professor>.Pesquisar();

            lstProfessores.BeginUpdate();

            lstProfessores.Items.Clear();

            if (lista != null)
            {
                foreach (Professor Professor in lista)
                {
                    IncluirNovoItem(Professor);
                }
            }

            lstProfessores.EndUpdate();

            HabilitaBotoes();

            Cursor.Current = Cursors.Default;
        }

        private void IncluirNovoItem(Professor Professor)
        {
            ListViewItem item = new ListViewItem(Professor.Id.ToString());
            item.BackColor = Professor.Ativo ? Color.White : Color.LightSalmon;
            item.Tag = Professor.Id;

            item.SubItems.Add(Professor.Codigo);
            item.SubItems.Add(Professor.Nome);

            lstProfessores.Items.Add(item);
        }
        private void AtualizaItemSelecionado(Professor Professor)
        {
            ListViewItem item = lstProfessores.SelectedItems[0];

            item.SubItems.Clear();

            item.Text = Professor.Id.ToString();
            item.BackColor = Professor.Ativo ? Color.White : Color.LightSalmon;
            item.SubItems.Add(Professor.Codigo);
            item.SubItems.Add(Professor.Nome);
        }

        private void Visualizar()
        {
            FormProfessor frmProfessor = new FormProfessor();

            frmProfessor.SetOperacao(TipoOperacaoCadastro.Visualizar, GetIdItemSelecionado(lstProfessores));

            frmProfessor.ShowDialog(this);
        }

        private void Incluir()
        {
            FormProfessor frmProfessor = new FormProfessor();

            Professor professor = null;

            frmProfessor.SetOperacao(TipoOperacaoCadastro.Incluir, 0);

            frmProfessor.SetEventRetorno(new EventHandler<Professor>(delegate (Object o, Professor a)
            {
                professor = a;
            }));

            frmProfessor.ShowDialog(this);

            if (professor != null)
            {
                lstProfessores.BeginUpdate();

                IncluirNovoItem(professor);

                lstProfessores.EndUpdate();
            }

        }
        private void Alterar()
        {
            FormProfessor frmProfessor = new FormProfessor();

            Professor professor = null;

            frmProfessor.SetOperacao(TipoOperacaoCadastro.Alterar, GetIdItemSelecionado(lstProfessores));

            frmProfessor.SetEventRetorno(new EventHandler<Professor>(delegate (Object o, Professor a)
            {
                professor = a;
            }));

            frmProfessor.ShowDialog(this);

            if (professor != null)
            {
                AtualizaItemSelecionado(professor);
            }
        }
        private void Excluir()
        {
            FormProfessor frmProfessor = new FormProfessor();

            Professor professor = null;

            frmProfessor.SetOperacao(TipoOperacaoCadastro.Excluir, GetIdItemSelecionado(lstProfessores));

            frmProfessor.SetEventRetorno(new EventHandler<Professor>(delegate (Object o, Professor a)
                            {
                                professor = a;
                            }));

            frmProfessor.ShowDialog(this);

            if (professor != null)
            {
                RemoveItemSelecionado(lstProfessores);
            }

        }
    }
}