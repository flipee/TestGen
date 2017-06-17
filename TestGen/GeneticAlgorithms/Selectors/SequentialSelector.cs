using System;

namespace TestGen.GeneticAlgorithms
{
    public class SequentialSelector : IGenomeSelector
    {
        private GenomeCollection genomes;
        public SequentialSelector(GenomeCollection genomes)
        {
            this.genomes = genomes;
        }

        #region IGenomeSelector Members
        public GenomeCollection Genomes
        {
            get { return genomes; }
            set { genomes = value; }
        }

        private int _currentIndex = 0;
        public Genome Select()
        {
            return genomes[(_currentIndex++) % genomes.Count];
        }
        public void OnNewGeneration(object sender, EventArgs args)
        {
            _currentIndex = 0;
        }
        #endregion
    }
}
