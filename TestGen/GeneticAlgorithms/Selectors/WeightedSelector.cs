using System;

namespace TestGen.GeneticAlgorithms
{
	public class WeightedSelector : IGenomeSelector
	{
        private GenomeCollection genomes;
        public WeightedSelector(GenomeCollection genomes)
		{
			this.genomes=genomes;
		}

		#region IGenomeSelector Members
		public GenomeCollection Genomes
		{
			get { return genomes; }
			set { genomes=value; }
		}

        public Genome Select()
        {
            int selectedIndex = -1;

            int searchSpaceStart = 0;
            int searchSpaceEnd = genomes.Count - 1;
            int currentSearchNode = (searchSpaceEnd / 2);

            if ((genomes[searchSpaceEnd].Fitness - genomes[0].Fitness) == 0)
                return genomes[GeneticAlgorithmUtility.RandomProvider.Next(genomes.Count)];

            double scaledProbability = (GeneticAlgorithmUtility.RandomProvider.NextDouble() * (genomes[searchSpaceEnd].Fitness - genomes[0].Fitness)) + genomes[0].Fitness;

            while (selectedIndex == -1)
            {
                if (scaledProbability < genomes[currentSearchNode].Fitness)
                {
                    searchSpaceEnd = currentSearchNode;
                }
                else
                {
                    searchSpaceStart = currentSearchNode;
                }
                currentSearchNode = (searchSpaceStart + searchSpaceEnd) / 2;

                if ((searchSpaceEnd - searchSpaceStart) == 1)
                    selectedIndex = searchSpaceEnd;
            }

            return genomes[selectedIndex];
        }
		#endregion
	}
}
