using System;

namespace TestGen.GeneticAlgorithms
{
    abstract public class Genome : IComparable
	{
		protected GeneticAlgorithm Parent;
        private int generation = 0;
        private double fitness = double.MinValue;
        protected Genome(GeneticAlgorithm parent)
		{
			Parent=parent;
		}
        public int Generation
        {
            get { return generation; }
            set { generation = value; }
        }
        public double Fitness
		{
			get { return fitness; }
			set { fitness=value; }
		}

		#region IComparable Members
		public int CompareTo(object obj)
		{			
			Genome compared=(Genome)obj;

            if (this.Fitness<compared.Fitness)
				return -1;
			else if(this.Fitness>compared.Fitness)
				return 1;
			else
				return 0;
		}
		#endregion
	}
}
