using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestGen
{
    [Serializable]
    public class ColControlTipoQuestao : CollectionBase
    {
        private int qtdMaxima = 0;
        public ColControlTipoQuestao()
        {

        }

        #region Properties
        public ItemControlTipoQuestao this[int index]
        {
            get
            {
                return (ItemControlTipoQuestao)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }

        public int QtdMaxima
        {
            get { return qtdMaxima; }
            set { qtdMaxima = value; ConfigureQtdMaxima(); }
        }

        public bool IsAllValid
        {
            get
            {
                return FirstInvalid < 0;
            }
        }

        public int FirstInvalid
        {
            get
            {
                int ret = -1;

                foreach (ItemControlTipoQuestao item in this)
                {
                    if (!item.IsValid)
                        ret = item.Index;

                    if (ret >= 0)
                        break;
                }

                return ret;
            }
        }

        public int HasConfiguratedRules
        {
            get
            {
                int ret = 0;

                foreach (ItemControlTipoQuestao item in this)
                {
                    if (item.IsConfigurated)
                        ret++;
                }

                return ret;
            }
        }

        #endregion

        #region Public Methods

        public int IndexOf(ItemControlTipoQuestao itemControlTipoQuestao)
        {
            if (itemControlTipoQuestao != null)
            {
                return base.List.IndexOf(itemControlTipoQuestao);
            }
            return -1;
        }

        public int Add(ItemControlTipoQuestao itemControlTipoQuestao)
        {
            if (itemControlTipoQuestao != null)
            {
                return this.List.Add(itemControlTipoQuestao);
            }
            return -1;
        }

        public int AddRule(TipoDeQuestao tipoQuestao,CheckBox chkAtivo,NumericUpDown numQuantidade)
        {
            if (chkAtivo != null && numQuantidade != null)
            {
                ItemControlTipoQuestao itemControlTipoQuestao = new ItemControlTipoQuestao(this.Count,tipoQuestao,chkAtivo,numQuantidade, qtdMaxima);

                return this.List.Add(itemControlTipoQuestao);
            }

            return -1;
        }
        public void Remove(ItemControlTipoQuestao itemControlTipoQuestao)
        {
            this.InnerList.Remove(itemControlTipoQuestao);
        }

        public void AddRange(ColControlTipoQuestao collection)
        {
            if (collection != null)
            {
                this.InnerList.AddRange(collection);
            }
        }

        public void Insert(int index, ItemControlTipoQuestao itemControlTipoQuestao)
        {
            if (index <= List.Count && itemControlTipoQuestao != null)
            {
                this.List.Insert(index, itemControlTipoQuestao);
            }
        }

        public bool Contains(ItemControlTipoQuestao itemControlTipoQuestao)
        {
            return this.List.Contains(itemControlTipoQuestao);
        }

        public ConfigTipoQuestao[] GetValidConfigTipoQuestao()
        {
            List<ConfigTipoQuestao> list = new List<ConfigTipoQuestao>();

            ConfigTipoQuestao conf;

            foreach (ItemControlTipoQuestao item in this)
            {
                if (item.IsConfigurated && item.IsValid)
                {
                    conf = new ConfigTipoQuestao();

                    conf.Index = item.Index;

                    conf.TipoQuestao = item.TipoQuestao;

                    if (item.ChkAtivo != null)
                        conf.Ativo = item.ChkAtivo.Enabled;

                    if (item.NumQuantidade != null)
                        conf.Quantidade = (int)item.NumQuantidade.Value;

                    list.Add(conf);
                }
            }

            return list.ToArray();
        }
        public ConfigTipoQuestao[] GetConfigTipoQuestoes()
        {
            List<ConfigTipoQuestao> list = new List<ConfigTipoQuestao>();

            ConfigTipoQuestao conf;

            foreach (ItemControlTipoQuestao item in this)
            {
                conf = new ConfigTipoQuestao();

                conf.Index = item.Index;

                conf.TipoQuestao = item.TipoQuestao;

                if (item.ChkAtivo != null)
                    conf.Ativo = item.ChkAtivo.Checked;

                if (item.NumQuantidade != null)
                    conf.Quantidade = (int)item.NumQuantidade.Value;

                list.Add(conf);
            }

            return list.ToArray();
        }

        public void InitFromConfigTipoQuestoes(ConfigTipoQuestao[] list)
        {
            if (list != null)
            {
                foreach (ConfigTipoQuestao item in list)
                {
                    this[item.Index].TipoQuestao = item.TipoQuestao;

                    if (this[item.Index].ChkAtivo != null)
                        this[item.Index].ChkAtivo.Checked = item.Ativo;

                    if (this[item.Index].NumQuantidade != null)
                        this[item.Index].NumQuantidade.Value = item.Quantidade;
                }
            }
            else
                ConfiguracaoDefault();
        }

        public void EnableAllControls(bool enabled)
        {
            foreach (ItemControlTipoQuestao item in this)
            {
                if (item.ChkAtivo != null)
                    item.ChkAtivo.Enabled = enabled;

                if (item.NumQuantidade != null)
                    item.NumQuantidade.Enabled = enabled && item.ChkAtivo!=null && item.ChkAtivo.Checked;
            }
        }

        public void ConfiguracaoDefault()
        {
            foreach (ItemControlTipoQuestao item in this)
            {
                if (item.ChkAtivo != null)
                    item.ChkAtivo.Checked = false;

                if (item.NumQuantidade != null)
                {
                    item.NumQuantidade.Value = 0;
                    item.NumQuantidade.Enabled = item.ChkAtivo != null && item.ChkAtivo.Checked;
                }
            }
        }

        #endregion

        #region Private Methods

        private void ConfigureQtdMaxima()
        {
                foreach (ItemControlTipoQuestao item in this)
                {
                    item.QtdMaxima = qtdMaxima;
                }
            
        }

        #endregion
    }
}
