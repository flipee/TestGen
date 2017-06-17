using System;

namespace TestGen.GeneticAlgorithms
{
    public class RandomSelector : IGenomeSelector
    {
        private GenomeCollection genomes;
        public RandomSelector(GenomeCollection genomes)
        {
            this.genomes = genomes;
        }
        #region IGenomeSelector Members
        public GenomeCollection Genomes
        {
            get { return genomes; }
            set { genomes = value; }
        }

        public Genome Select()
        {
            return genomes[GeneticAlgorithmUtility.RandomProvider.Next(genomes.Count)];
        }
        #endregion
    }
}
