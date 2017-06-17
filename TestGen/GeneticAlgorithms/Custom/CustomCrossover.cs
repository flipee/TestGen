using TestGen.GeneticAlgorithms;

namespace TestGen
{
    public class CustomCrossover : ICrossover
    {
        private double crossoverP = 0.25;
        private double mutationP = 0.008;
        private double mutationFactor = 0.25;
        protected double valueDeltaCoef = 0;
        public CustomCrossover()
        {

        }
        public double CrossoverProbability
        {
            get { return crossoverP; }
            set { crossoverP = value; }
        }
        public double MutationProbability
        {
            get { return mutationP; }
            set { mutationP = value; }
        }
        public double MutationFactor
        {
            get { return mutationFactor; }
            set { mutationFactor = value; }
        }
        public virtual Genome Crossover(Genome first, Genome second,int generation)
        {
            CustomGenome firstR = (CustomGenome)first;
            CustomGenome secondR = (CustomGenome)second;
            double d = 0;

            bool changed = false;

            for (int g = 0; g < firstR.Length; g++)
            {
                d = GeneticAlgorithmUtility.RandomProvider.NextDouble();

                if (d <= crossoverP)
                {
                    firstR[g] = secondR[g];
                    changed = true;
                }

                d = GeneticAlgorithmUtility.RandomProvider.NextDouble();

                if (d <= mutationP)
                {
                    firstR[g] = GeneticAlgorithmUtility.RandomProvider.Next(0, firstR.MaxValue + 1);
                    changed = true;
                }
            }

            if (changed)
                firstR.Generation = generation;

            return first;
        }
    }
}
