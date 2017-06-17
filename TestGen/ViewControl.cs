using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace TestGen
{
    public static class ViewControl
    {
        public enum TipoOperacaoCadastro
        {
            Visualizar,
            Incluir,
            Alterar,
            Excluir
        }

        public static int GetIdItemSelecionado(ListView lstview)
        {
            int ret = 0;

            if (lstview.SelectedItems.Count > 0)
                ret = (int)lstview.SelectedItems[0].Tag;

            return ret;
        }

        public static void RemoveItemSelecionado(ListView lstview)
        {
            if (lstview.SelectedItems.Count > 0)
                lstview.SelectedItems[0].Remove();
        }
        public static bool CarregarComboTipoCadastro(ComboBox combo)
        {
            BindingList<KeyValuePair<string, int>> items = new BindingList<KeyValuePair<string, int>>();

            items.Add(new KeyValuePair<string, int>("", 0));
            items.Add(new KeyValuePair<string, int>("Discursiva", (int)TipoDeQuestao.Discursiva));
            items.Add(new KeyValuePair<string, int>("Escolha Simples", (int)TipoDeQuestao.EscolhaSimples));
            items.Add(new KeyValuePair<string, int>("Múltipla Escolha", (int)TipoDeQuestao.MultiplaEscolha));
            items.Add(new KeyValuePair<string, int>("Lista de Associação", (int)TipoDeQuestao.ListaDeAssociacao));

            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            combo.DisplayMember = "Key";
            combo.ValueMember = "Value";
            combo.DataSource = items;

            return true;
        }

        public static bool CarregarComboSeletorGA(ComboBox combo)
        {
            BindingList<KeyValuePair<string, int>> items = new BindingList<KeyValuePair<string, int>>();

            items.Add(new KeyValuePair<string, int>("Roleta", (int)SeletorGA.Roleta));
            items.Add(new KeyValuePair<string, int>("Sequencial", (int)SeletorGA.Sequencial));
            items.Add(new KeyValuePair<string, int>("Randômico", (int)SeletorGA.Randomico));

            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            combo.DisplayMember = "Key";
            combo.ValueMember = "Value";
            combo.DataSource = items;

            return true;
        }
        public static bool CarregarComboTipoAvaliacao(ComboBox combo)
        {
            BindingList<KeyValuePair<string, int>> items = new BindingList<KeyValuePair<string, int>>();

            items.Add(new KeyValuePair<string, int>("P1", 1));
            items.Add(new KeyValuePair<string, int>("P2", 2));
            items.Add(new KeyValuePair<string, int>("P3", 3));

            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            combo.DisplayMember = "Key";
            combo.ValueMember = "Value";
            combo.DataSource = items;

            return true;
        }

        public static bool CarregarComboAtivo<T1>(ComboBox combo)
        {
            Expression<Func<T1, bool>> expression = null;

            if (typeof(Ativable).IsAssignableFrom(typeof(T1)))
            {
                expression = x => (x as Ativable).Ativo;
            }

            return CarregarCombo<T1>(combo, 0, expression);
        }

        public static bool CarregarCombo<T1>(ComboBox combo, int id)
        {
            return CarregarCombo<T1>(combo, id, null);
        }

        public static bool CarregarCombo<T1>(ComboBox combo)
        {
            return CarregarCombo<T1>(combo, 0, null);
        }

        public static bool CarregarCombo<T1>(ComboBox combo,int id, Expression<Func<T1, bool>> expression)
        {
            bool ret = false;

            BindingList<KeyValuePair<string, int>> items = new BindingList<KeyValuePair<string, int>>();

            List<T1> list;

            if (id == 0)
            {
                if (expression != null)
                    list = DBControl.Table<T1>.Pesquisar(expression);
                else
                    list = DBControl.Table<T1>.Pesquisar();
            }
            else
            {
                list = DBControl.Table<T1>.Pesquisar(id);
            }

            if (list != null)
            {
                int value;
                string key;

                items.Add(new KeyValuePair<string, int>("", 0));

                foreach (T1 a in list)
                {
                    value = ((IdentityColumn)a).Id;
                    key = ((Nameable)a).Nome;

                    items.Add(new KeyValuePair<string, int>(key, value));
                }

                combo.DropDownStyle = ComboBoxStyle.DropDown;
                combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combo.AutoCompleteSource = AutoCompleteSource.ListItems;
                combo.DisplayMember = "Key";
                combo.ValueMember = "Value";
                combo.DataSource = items;

                ret = true;
            }

            return ret;
        }

        public static int GetIdItemCombo(ComboBox combo)
        {
            int ret = 0;

            if (combo.SelectedItem != null)
                ret = (int)combo.SelectedValue;

            return ret;
        }

        public static void SelectComboBoxByValue(ComboBox combo, int id)
        {
            combo.SelectedValue = id;
        }
    }
}
