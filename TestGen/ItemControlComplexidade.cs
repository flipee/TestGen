using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGen
{
    public class ItemControlComplexidade
    {
        private NumericUpDown numUpDownIni;
        private NumericUpDown numUpDownFim;
        private NumericUpDown numUpDownQtd;
        private int qtdMaxima;

        public int Index { get; set; }
        public NumericUpDown NumUpDownIni
        {
            get { return numUpDownIni; }
            set { numUpDownIni = value; ConfigureUpDowIni(); }
        }
        public NumericUpDown NumUpDownFim
        {
            get { return numUpDownFim; }
            set { numUpDownFim = value; ConfigureUpDowFim(); }
        }
        public NumericUpDown NumUpDownQtd
        {
            get { return numUpDownQtd; }
            set { numUpDownQtd = value; ConfigureUpDowQtd(); }
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
                bool ret = numUpDownIni != null && numUpDownFim != null && numUpDownQtd != null;

                if (ret)
                {
                    int count = 0;

                    if (numUpDownIni.Value > 0)
                        count++;

                    if (numUpDownFim.Value > 0)
                        count++;

                    if (numUpDownQtd.Value > 0)
                        count++;

                    ret = count > 0;
                }

                return ret;
            }
        }

        public bool IsValid
        {
            get
            {
                bool ret = numUpDownIni != null && numUpDownFim != null && numUpDownQtd != null;

                if (ret)
                {
                    int count = 0;

                    if (numUpDownIni.Value > 0)
                        count++;

                    if (numUpDownFim.Value > 0)
                        count++;

                    if (numUpDownQtd.Value > 0)
                        count++;

                    ret = count == 0 || count == 3;
                }

                return ret;
            }
        }
        public ItemControlComplexidade(int index, NumericUpDown numUpDownIni, NumericUpDown numUpDownFim, NumericUpDown numUpDownQtd,int qtdMaxima)
        {
            Index = index;
            NumUpDownIni = numUpDownIni;
            NumUpDownFim = numUpDownFim;
            NumUpDownQtd = numUpDownQtd;
            QtdMaxima = qtdMaxima;
        }

        private void OnValueChangedIni(object sender, EventArgs e)
        {
            if (numUpDownFim != null)
            {
                if (numUpDownIni.Value > numUpDownFim.Value)
                    numUpDownFim.Value = numUpDownIni.Value;
            }
        }
        private void OnValueChangedFim(object sender, EventArgs e)
        {
            if (numUpDownIni != null)
            {
                if (numUpDownFim.Value < numUpDownIni.Value)
                    numUpDownIni.Value = numUpDownFim.Value;
            }
        }
        private void ConfigureUpDowIni()
        {
            if (numUpDownIni != null)
            {
                numUpDownIni.ValueChanged += new System.EventHandler(this.OnValueChangedIni);
                numUpDownIni.Minimum = 0;
                numUpDownIni.Maximum = 10;
            }
        }
        private void ConfigureUpDowFim()
        {
            if (numUpDownFim != null)
            {
                numUpDownFim.ValueChanged += new System.EventHandler(this.OnValueChangedFim);
                numUpDownFim.Minimum = 0;
                numUpDownFim.Maximum = 10;
            }
        }
        private void ConfigureUpDowQtd()
        {
            if (numUpDownQtd != null)
            {
                numUpDownQtd.Minimum = 0;
                numUpDownQtd.Maximum = QtdMaxima;
            }
        }

        private void ConfigureQtdMaxima()
        {
            if (numUpDownQtd != null)
            {
                numUpDownQtd.Maximum = qtdMaxima;
            }
        }
    }
}
