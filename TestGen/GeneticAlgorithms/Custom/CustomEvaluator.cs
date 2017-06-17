using System;
using System.Collections.Generic;
using System.Text;
using TestGen.GeneticAlgorithms;

namespace TestGen
{
    public class CustomEvaluator : IEvaluateGenome
    {
        ParametersGeneticAlgorithm parameters;

        public CustomEvaluator(ParametersGeneticAlgorithm parameters)
        {
            this.parameters = parameters;
        }
        #region IEvaluateGenome Members

        public double Eval(Genome candidate)
        {
            CustomGenome genome = (CustomGenome)candidate;

            genome.UpdateStat(parameters);

            double ret = 0;

            ret += Math.Abs(genome.QtdTotal() - genome.Length) * 200;

            if (parameters.TempoPrevistoAvaliacao>0)
                ret += Math.Abs(genome.TempoTotal() - parameters.TempoPrevistoAvaliacao);

            foreach(ConfigComplexidade rule in parameters.ComplexRules)
            {
                ret += Math.Abs(genome.ComplexTotal(rule.ComplexIni,rule.ComplexFim) - rule.Quantidade) * 100;
            }

            int tipoQuestao;

            foreach (ConfigTipoQuestao rule in parameters.TipoQuestaoRules)
            {
                tipoQuestao = (int)rule.TipoQuestao;

                ret += Math.Abs(genome.TipoTotal(tipoQuestao, tipoQuestao) - rule.Quantidade) * 100;
            }

            if (ret > (double)int.MaxValue)
                ret = (double)int.MaxValue;

            return (((double)int.MaxValue) - ret) / ((double)int.MaxValue) * 100.0;
        }

        #endregion
        /*
        static public String ListaToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ids.Length; i++)
            {
                sb.Append("Item ");
                sb.Append(string.Format("{0,5}", ids[i]));
                sb.Append(" -> Complexidade: ");
                sb.Append(complexidades[ids[i]].ToString());
                sb.Append("\tTipo: ");
                sb.Append(tipos[ids[i]].ToString());
                sb.Append("\tPeso: ");
                sb.Append(string.Format("{0,5}", pesos[ids[i]]));
                sb.Append("\tTempo: ");
                sb.Append(string.Format("{0,5}", tempos[ids[i]]));
                sb.Append("\n");
            }

            return sb.ToString();
        }
        */
    }
}
