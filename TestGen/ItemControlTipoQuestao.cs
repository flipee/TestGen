using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGen
{
    public class ItemControlTipoQuestao
    {
        private CheckBox chkAtivo;
        private NumericUpDown numQuantidade;
        private int qtdMaxima;

        public int Index { get; set; }
        public TipoDeQuestao TipoQuestao { get; set; }
        public CheckBox ChkAtivo
        {
            get { return chkAtivo; }
            set { chkAtivo = value; ConfigureCheckBox(); }
        }
        public NumericUpDown NumQuantidade
        {
            get { return numQuantidade; }
            set { numQuantidade = value; ConfigureUpDow(); }
        }
        public int QtdMaxima
        {
            get { return qtdMaxima; }
            set { qtdMaxima = value; ConfigureQtdMaxima(); }
        }
        public bool IsConfigurated
        {
            get
            {
                bool ret = chkAtivo != null && numQuantidade != null;

                if (ret)
                {
                    ret = chkAtivo.Checked || numQuantidade.Value > 0;
                }

                return ret;
            }
        }

        public bool IsValid
        {
            get
            {
                bool ret = chkAtivo != null && numQuantidade != null;

                if (ret)
                {
                    ret = chkAtivo.Checked || (numQuantidade.Value == 0 && !chkAtivo.Checked);
                }

                return ret;
            }
        }
        public ItemControlTipoQuestao(int index, TipoDeQuestao tipoQuestao, CheckBox chkAtivo, NumericUpDown numQuantidade, int qtdMaxima)
        {
            Index = index;
            TipoQuestao = tipoQuestao;
            ChkAtivo=chkAtivo;
            NumQuantidade = numQuantidade;
            QtdMaxima = qtdMaxima;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {

        }
        private void OnCheckedChanged(object sender, EventArgs e)
        {
            if (numQuantidade != null)
            {
                numQuantidade.Enabled = chkAtivo.Checked;
                if (!numQuantidade.Enabled)
                    numQuantidade.Value = 0;
            }
        }
        private void ConfigureQtdMaxima()
        {
            if (numQuantidade != null)
            {
                numQuantidade.Maximum = qtdMaxima;
            }
        }
        private void ConfigureCheckBox()
        {
            if (chkAtivo != null)
            {
                chkAtivo.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);

                if (numQuantidade != null)
                    numQuantidade.Enabled = chkAtivo.Checked;
            }
            else if (numQuantidade != null)
                numQuantidade.Enabled = false;
        }
        private void ConfigureUpDow()
        {
            if (numQuantidade != null)
            {
                numQuantidade.ValueChanged += new System.EventHandler(this.OnValueChanged);
                numQuantidade.Minimum = 0;
                numQuantidade.Maximum = qtdMaxima;

                if (chkAtivo != null)
                    numQuantidade.Enabled = chkAtivo.Checked;
                else
                    numQuantidade.Enabled = false;
            }
        }
    }
}
