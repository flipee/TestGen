using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using static TestGen.ViewControl;

namespace TestGen
{
    public partial class FormCadastroCursos : Form
    {
        public FormCadastroCursos()
        {
            InitializeComponent();
        }

        private void FormCadastroCursos_Load(object sender, EventArgs e)
        {
            lstCursos.View = View.Details;
            lstCursos.FullRowSelect = true;
            lstCursos.MultiSelect = false;
            lstCursos.HideSelection = false;

            lstCursos.Columns.Add("ID");
            lstCursos.Columns.Add("Código");
            lstCursos.Columns.Add("Nome");

            lstCursos.Columns[0].Width = 60;
            lstCursos.Columns[1].Width = 80;
            lstCursos.Columns[2].Width = 500;
        }
        private void FormCadastroCursos_Activated(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Tag = true;

                ExecutaPesquisa();
            }

        }

        private void lstCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitaBotoes();
        }
        private void lstCursos_DoubleClick(object sender, EventArgs e)
        {
            if (lstCursos.SelectedItems.Count > 0)
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
            bool itemselecionado = lstCursos.SelectedItems.Count > 0;

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

            Expression<Func<Curso, bool>> expression = null;

            if (codigo != null && !codigo.Equals(""))
            {
                expression = x => x.Codigo.Contains(codigo);
            }

            if (nome != null && !nome.Equals(""))
            {
                expression = x => x.Nome.Contains(nome);
            }

            List<Curso> lista;

            if (expression != null)
                lista = DBControl.Table<Curso>.Pesquisar(expression);
            else
                lista = DBControl.Table<Curso>.Pesquisar();

            lstCursos.BeginUpdate();

            lstCursos.Items.Clear();

            if (lista != null)
            {
                lstCursos.BeginUpdate();

                foreach (Curso curso in lista)
                {
                    IncluirNovoItem(curso);
                }

                lstCursos.EndUpdate();
            }

            lstCursos.EndUpdate();

            HabilitaBotoes();

            Cursor.Current = Cursors.Default;
        }

        private void IncluirNovoItem(Curso curso)
        {
            ListViewItem item = new ListViewItem(curso.Id.ToString());
            item.BackColor = curso.Ativo ? Color.White : Color.LightSalmon;
            item.Tag = curso.Id;

            item.SubItems.Add(curso.Codigo);
            item.SubItems.Add(curso.Nome);

            lstCursos.Items.Add(item);
        }
        private void AtualizaItemSelecionado(Curso curso)
        {
            ListViewItem item = lstCursos.SelectedItems[0];

            item.SubItems.Clear();

            item.Text = curso.Id.ToString();
            item.BackColor = curso.Ativo ? Color.White : Color.LightSalmon;
            item.SubItems.Add(curso.Codigo);
            item.SubItems.Add(curso.Nome);
        }

        private void Visualizar()
        {
            FormCurso frmCurso = new FormCurso();

            frmCurso.SetOperacao(TipoOperacaoCadastro.Visualizar, GetIdItemSelecionado(lstCursos));

            frmCurso.ShowDialog(this);
        }

        private void Incluir()
        {
            FormCurso frmCurso = new FormCurso();

            Curso curso = null;

            frmCurso.SetOperacao(TipoOperacaoCadastro.Incluir, 0);

            frmCurso.SetEventRetorno(new EventHandler<Curso>(delegate (Object o, Curso a)
            {
                curso = a;
            }));

            frmCurso.ShowDialog(this);

            if (curso != null)
            {
                lstCursos.BeginUpdate();

                IncluirNovoItem(curso);

                lstCursos.EndUpdate();
            }

        }
        private void Alterar()
        {
            FormCurso frmCurso = new FormCurso();

            Curso curso = null;

            frmCurso.SetOperacao(TipoOperacaoCadastro.Alterar, GetIdItemSelecionado(lstCursos));

            frmCurso.SetEventRetorno(new EventHandler<Curso>(delegate (Object o, Curso a)
            {
                curso = a;
            }));

            frmCurso.ShowDialog(this);

            if (curso!=null)
            {
                AtualizaItemSelecionado(curso);
            }
        }
        private void Excluir()
        {
            FormCurso frmCurso = new FormCurso();

            Curso curso = null;

            frmCurso.SetOperacao(TipoOperacaoCadastro.Excluir, GetIdItemSelecionado(lstCursos));

            frmCurso.SetEventRetorno(new EventHandler<Curso>(delegate (Object o, Curso a)
                            {
                                curso=a;
                            }));

            frmCurso.ShowDialog(this);

            if (curso!=null)
            {
                RemoveItemSelecionado(lstCursos);
            }

        }

        private void teste()
        {
            Curso curso;

            for (int i = 1; i < 10000; i++)
            {
                curso = new Curso();

                curso.Codigo = "XXX" + i.ToString();
                curso.Nome = "Teste" + i.ToString();
                curso.Ativo = (i % 10) != 0;

                int idCurso = DBControl.Table<Curso>.Incluir(curso);
            }

            /*
            Questao questao = new Questao();

            questao.TipoQuestao = TipoDeQuestao.Discursiva;
            questao.SequenciaImpressao = "EIR";

            questao.Validar();
            */
            /*
            Curso curso = new Curso();

            curso.Codigo = "XXX";
            curso.Nome = "Teste";
            curso.Ativo = true;

            int idCurso= DBControl.Table<Curso>.Incluir(curso);

            Professor professor = new Professor();

            professor.Codigo = "AABB";
            professor.Nome = "Teste";
            professor.Email = "teste@teste";

            int idProfessor = DBControl.Table<Professor>.Incluir(professor);

            Disciplina disciplina = new Disciplina();

            disciplina.Codigo = "TTAA";
            disciplina.Nome = "Teste";
            disciplina.IdCurso = idCurso;
            disciplina.IdProfessor = idProfessor;

            int idDisciplina = DBControl.Table<Disciplina>.Incluir(disciplina);
            */

            //bool exlcluido =DBControl.Table<Professor>.Excluir(1);


            //List<Curso> lista = DBControl.Table<Curso>.Pesquisar(x => x.Codigo.Equals("UCD"));
        }
    }
}