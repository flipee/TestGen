using System.Collections.Generic;
using TestGen.GeneticAlgorithms;

namespace TestGen
{
    public class CustomFactory : IGenomeFactory
    {
        private int minValue;
        private int maxValue;
        private int numberOfValues;
        public CustomFactory(int minValue, int maxValue, int numberOfValues)
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
            this.numberOfValues = numberOfValues;
        }
        #region IGenomeFactory Members


        public Genome CreateGenome(GeneticAlgorithm parent)
        {
            CustomGenome newCustomGenome = new CustomGenome(parent, numberOfValues);
            newCustomGenome.MaxValue = maxValue;
            newCustomGenome.MinValue = minValue;
            RandomizeGenome(newCustomGenome);
            return newCustomGenome;
        }
        #endregion
        public void RandomizeGenome(CustomGenome value)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < value.Length; i++)
            {
                while (true)
                {
                    value[i] = GeneticAlgorithmUtility.RandomProvider.Next(minValue, maxValue + 1);

                    if (value[i] > maxValue)
                        value[i] = maxValue;

                    if (!list.Exists(x => x == value[i]))
                    {
                        list.Add(value[i]);
                        break;
                    }
                }
            }
        }

    }
}
