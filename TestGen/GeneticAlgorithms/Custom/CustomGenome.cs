using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestGen.GeneticAlgorithms;

namespace TestGen
{
    public class CustomGenome : Genome
    {
        private GeneticAlgorithm ga;
        private int[] alleles;
        private int maxValue = int.MaxValue;
        private int minValue = int.MinValue;
        private bool pendStat = true;

        private double qtdTotal = 0;
        private double tempoTotal = 0;
        private double[] totalNiveisComplex = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private double[] totalTipos = { 0, 0, 0, 0 };

        public CustomGenome(GeneticAlgorithm parent, int numberOfValues) : base(parent)
        {
            this.ga = parent;
            this.alleles = new int[numberOfValues];
        }

        public int this[int index]
        {
            get { return alleles[index]; }
            set
            {
                alleles[index] = value;

                if (alleles[index] > maxValue)
                    alleles[index] = maxValue;
                if (alleles[index] < minValue)
                    alleles[index] = minValue;

                pendStat = true;
            }
        }

        public int[] Alleles
        {
            get { return alleles; }
        }
        public int Length
        {
            get { return alleles.Length; }
        }

        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            List<int> list = new List<int>(alleles);

            foreach (int value in list)
                sb.Append("|").Append(((List<Questao>)ga.CustomObj)[value].Id.ToString());

            return sb.ToString().Substring(1);
        }

        public override int GetHashCode()
        {
            return ToOrderedString().GetHashCode();
        }

        public string ToOrderedString()
        {
            StringBuilder sb = new StringBuilder();

            List<int> list = new List<int>(alleles);

            list.Sort();

            foreach (int value in list)
                sb.Append("|").Append(((List<Questao>)ga.CustomObj)[value].Id.ToString());
            
            return sb.ToString().Substring(1);
        }

        public List<Questao> Questoes()
        {
            List<Questao> ret = new List<Questao>();

            List <int> list = new List<int>(alleles);

            foreach (int value in list)
                ret.Add(((List<Questao>)ga.CustomObj)[value]);

            return ret;
        }

        public List<int> IdsQuestoes()
        {
            List<int> ret = new List<int>();

            List<int> list = new List<int>(alleles);

            foreach (int value in list)
                ret.Add(((List<Questao>)ga.CustomObj)[value].Id);

            return ret;
        }

        public double QtdTotal()
        {
            return qtdTotal;
        }
        public double TempoTotal()
        {
            return tempoTotal;
        }
        public double ComplexTotal(int compini, int compfim)
        {
            double ret = 0;

            for (int i = compini; i <= compfim; i++)
            {
                ret += totalNiveisComplex[i - 1];
            }

            return ret;
        }
        public double TipoTotal(int tipoini, int tipofim)
        {
            double ret = 0;

            for (int i = tipoini; i <= tipofim; i++)
            {
                ret += totalTipos[i - 1];
            }

            return ret;
        }
        public void UpdateStat(ParametersGeneticAlgorithm parameters)
        {
            if (!pendStat)
                return;

            qtdTotal = 0;
            tempoTotal = 0;

            for (int i = 0; i < totalNiveisComplex.Length; i++)
            {
                totalNiveisComplex[i] = 0;
            }

            for (int i = 0; i < totalTipos.Length; i++)
            {
                totalTipos[i] = 0;
            }

            List<int> list = new List<int>();

            int[] ids = new int[this.Length];

            Questao questao;

            for (int i = 0; i < this.Length; i++)
            {
                ids[i] = this[i];

                if (!list.Contains(ids[i]))
                {
                    qtdTotal++;
                    list.Add(ids[i]);
                }

                questao = parameters.Questoes[ids[i]];

                tempoTotal += questao.TempoResposta;

                totalNiveisComplex[questao.Complexidade - 1]++;

                totalTipos[(int)questao.TipoQuestao - 1]++;
            }

            pendStat = false;
        }
    }
}
