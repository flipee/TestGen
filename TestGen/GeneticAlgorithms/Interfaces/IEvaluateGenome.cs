using System;

namespace TestGen.GeneticAlgorithms
{
	public interface IEvaluateGenome
	{
		double Eval(Genome candidate);
	}
}
