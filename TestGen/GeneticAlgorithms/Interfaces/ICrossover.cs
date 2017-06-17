using System;

namespace TestGen.GeneticAlgorithms
{
	public interface ICrossover
	{
		Genome Crossover(Genome first, Genome second, int generation);
		double CrossoverProbability { get;set; }
		double MutationProbability { get;set; }
	}
}
