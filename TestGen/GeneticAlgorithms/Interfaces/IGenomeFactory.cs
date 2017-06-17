using System;

namespace TestGen.GeneticAlgorithms
{
	public interface IGenomeFactory
	{
		Genome CreateGenome(GeneticAlgorithm parent);
	}
}
