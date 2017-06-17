using System;
using System.ComponentModel;

namespace TestGen.GeneticAlgorithms
{
    public delegate void GeneticAlgorithmEventHandler(GeneticAlgorithm sender, EventArgs args);
    public delegate void GeneticAlgorithmGenomeEventHandler(GeneticAlgorithm sender, GenomeEventArgs args);
    public delegate void GeneticAlgorithmCancelEventHandler(GeneticAlgorithm sender, GenomeCancelEventArgs args);

    public class GenomeEventArgs : EventArgs
    {
        public Genome Genome { get; set; }
    }

    public class GenomeCancelEventArgs : CancelEventArgs
    {
        public Genome Genome { get; set; }
    }
}
