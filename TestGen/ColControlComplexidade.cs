using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestGen
{
    [Serializable]
    public class ColControlComplexidade : CollectionBase
    {
        private int qtdMaxima = 0;
        public ColControlComplexidade()
        {

        }

        #region Properties
        public ItemControlComplexidade this[int index]
        {
            get
            {
                return (ItemControlComplexidade)this.List[index];
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

                foreach (ItemControlComplexidade item in this)
                {
                    if (!item.IsValid)
                        ret = item.Index;

                    if (ret>=0)
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

                foreach (ItemControlComplexidade item in this)
                {
                    if (item.IsConfigurated)
                        ret++;
                }

                return ret;
            }
        }

        #endregion

        #region Public Methods

        public int IndexOf(ItemControlComplexidade RuleNumUpDownComplexItem)
        {
            if (RuleNumUpDownComplexItem != null)
            {
                return base.List.IndexOf(RuleNumUpDownComplexItem);
            }
            return -1;
        }

        public int Add(ItemControlComplexidade RuleNumUpDownComplexItem)
        {
            if (RuleNumUpDownComplexItem != null)
            {
                return this.List.Add(RuleNumUpDownComplexItem);
            }
            return -1;
        }

        public int AddRule(NumericUpDown numUpDownIni, NumericUpDown numUpDownFim, NumericUpDown numUpDownQtd)
        {
            if (numUpDownIni!=null && numUpDownFim!=null && numUpDownQtd!=null)
            {
                ItemControlComplexidade ruleNumUpDownComplexItem = new ItemControlComplexidade(this.Count, numUpDownIni, numUpDownFim, numUpDownQtd, qtdMaxima);

                return this.List.Add(ruleNumUpDownComplexItem);
            }

            return -1;
        }
        public void Remove(ItemControlComplexidade RuleNumUpDownComplexItem)
        {
            this.InnerList.Remove(RuleNumUpDownComplexItem);
        }

        public void AddRange(ColControlComplexidade collection)
        {
            if (collection != null)
            {
                this.InnerList.AddRange(collection);
            }
        }

        public void Insert(int index, ItemControlComplexidade RuleNumUpDownComplexItem)
        {
            if (index <= List.Count && RuleNumUpDownComplexItem != null)
            {
                this.List.Insert(index, RuleNumUpDownComplexItem);
            }
        }

        public bool Contains(ItemControlComplexidade RuleNumUpDownComplexItem)
        {
            return this.List.Contains(RuleNumUpDownComplexItem);
        }

        public ConfigComplexidade[] GetValidConfigComplexidade()
        {
            List<ConfigComplexidade> list = new List<ConfigComplexidade>();

            ConfigComplexidade conf;

            foreach (ItemControlComplexidade item in this)
            {
                if (item.IsConfigurated && item.IsValid)
                {
                    conf = new ConfigComplexidade();

                    conf.Index = item.Index;

                    if (item.NumUpDownIni != null)
                        conf.ComplexIni = (int)item.NumUpDownIni.Value;

                    if (item.NumUpDownFim != null)
                        conf.ComplexFim = (int)item.NumUpDownFim.Value;

                    if (item.NumUpDownQtd != null)
                        conf.Quantidade = (int)item.NumUpDownQtd.Value;

                    list.Add(conf);
                }
            }

            return list.ToArray();
        }
        public ConfigComplexidade[] GetConfigComplexidade()
        {
            List<ConfigComplexidade> list = new List<ConfigComplexidade>();

            ConfigComplexidade conf;

            foreach(ItemControlComplexidade item in this)
            {
                conf = new ConfigComplexidade();

                conf.Index = item.Index;

                if (item.NumUpDownIni!=null)
                    conf.ComplexIni = (int)item.NumUpDownIni.Value;

                if (item.NumUpDownFim != null)
                    conf.ComplexFim = (int)item.NumUpDownFim.Value;

                if (item.NumUpDownQtd != null)
                    conf.Quantidade = (int)item.NumUpDownQtd.Value;

                list.Add(conf);
            }

            return list.ToArray();
        }

        public void InitFromConfigComplexidades(ConfigComplexidade[] list)
        {
            if (list != null)
            {
                foreach (ConfigComplexidade item in list)
                {
                    if (this[item.Index].NumUpDownIni != null)
                        this[item.Index].NumUpDownIni.Value = item.ComplexIni;

                    if (this[item.Index].NumUpDownFim != null)
                        this[item.Index].NumUpDownFim.Value = item.ComplexFim;

                    if (this[item.Index].NumUpDownQtd != null)
                        this[item.Index].NumUpDownQtd.Value = item.Quantidade;
                }
            }
            else
                ConfiguracaoDefault();
        }

        public void EnableAllControls(bool enabled)
        {
            foreach (ItemControlComplexidade item in this)
            {
                if (item.NumUpDownIni != null)
                    item.NumUpDownIni.Enabled = enabled;

                if (item.NumUpDownFim != null)
                    item.NumUpDownFim.Enabled = enabled;

                if (item.NumUpDownQtd != null)
                    item.NumUpDownQtd.Enabled = enabled;
            }
        }

        public void ConfiguracaoDefault()
        {
            foreach (ItemControlComplexidade item in this)
            {
                if (item.NumUpDownIni != null)
                    item.NumUpDownIni.Value = 0;

                if (item.NumUpDownFim != null)
                    item.NumUpDownFim.Value = 0;

                if (item.NumUpDownQtd != null)
                    item.NumUpDownQtd.Value = 0;
            }
        }

        #endregion

        #region Private Methods

        private void ConfigureQtdMaxima()
        {
            foreach(ItemControlComplexidade item in this)
            {
                item.QtdMaxima = qtdMaxima;
            }
        }

        #endregion
    }
}
