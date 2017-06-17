using System;

namespace TestGen.GeneticAlgorithms
{
	public interface IGenomeSelector
	{
		GenomeCollection Genomes{ get;set; }
		Genome Select();
	}
}
