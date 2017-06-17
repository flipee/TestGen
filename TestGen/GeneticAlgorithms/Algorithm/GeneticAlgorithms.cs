using System;
using System.ComponentModel;

namespace TestGen.GeneticAlgorithms
{
    public class GeneticAlgorithm
    {
        private double bestFitness = double.MinValue;
        private int populationSize = 0;
        private int generations = 0;
        private bool elitism = true;

        private object customObj = null;

        private DateTime startTime;

        private GenomeCollection gnomes = new GenomeCollection();

        private ExitConditions exitConditions = new ExitConditions();
        private IGenomeFactory genomeFactory;
        private ICrossover crossover;
        private IEvaluateGenome evaluator;
        private IGenomeSelector selector;

        public event GeneticAlgorithmEventHandler NewGeneration;
        public event GeneticAlgorithmGenomeEventHandler NewBestFitness;
        public event GeneticAlgorithmCancelEventHandler QryBestFitness;

        public GeneticAlgorithm()
        {

        }

        public DateTime StartTime
        {
            get { return startTime; }
        }
        public int GenerationCount
        {
            get { return generations; }
        }
        public GenomeCollection Genomes
        {
            get { return gnomes; }
        }
        public IGenomeSelector Selector
        {
            get { return selector; }
            set { selector = value; }
        }
        public IEvaluateGenome Evaluator
        {
            get { return evaluator; }
            set { evaluator = value; }
        }
        public ICrossover Crossover
        {
            get { return crossover; }
            set { crossover = value; }
        }
        public IGenomeFactory GenomeFactory
        {
            get { return genomeFactory; }
            set { genomeFactory = value; }
        }
        public ExitConditions ExitConditions
        {
            get { return exitConditions; }
            set { exitConditions = value; }
        }
        public bool Elitism
        {
            get { return elitism; }
            set { elitism = value; }
        }

        public object CustomObj
        {
            get { return customObj; }
            set { customObj = value; }
        }
        public void CreateGenomes(int populationSize)
        {
            if (GenomeFactory == null)
                throw new ApplicationException("Impossível criar genomas no algoritimo genético com o GenomeFactory nulo!");

            this.populationSize = populationSize;

            Genome[] genomes = new Genome[populationSize];
            for (int i = 0; i < populationSize; i++)
                gnomes.Add(GenomeFactory.CreateGenome(this));
        }
        public virtual Genome Execute()
        {
            if (Selector == null)
                throw new ApplicationException("Impossível executar o algoritimo genético com o Selector nulo!");

            if (Crossover == null)
                throw new ApplicationException("Impossível executar o algoritimo genético com o Crossover nulo!");

            startTime = DateTime.Now;

            int genomeCount = (elitism ? gnomes.Count - 1 : gnomes.Count);

            Genome[] mate = new Genome[genomeCount];

            while (true)
            {
                generations++;

                if (NewGeneration != null)
                    NewGeneration(this,null);

                for (int g = 0; g < genomeCount; g++)
                {
                    Genomes[g].Fitness = Evaluator.Eval(Genomes[g]);
                }

                Genomes.Sort();

                int gnomeIndex = Genomes.Count - 1;

                if (QryBestFitness != null)
                {
                    while (gnomeIndex >= 0 && Genomes[gnomeIndex].Fitness > bestFitness)
                    {
                        GenomeCancelEventArgs args = new GenomeCancelEventArgs();

                        args.Genome = Genomes[Genomes.Count - 1];

                        QryBestFitness(this, args);

                        if (args.Cancel)
                        {
                            Genomes[Genomes.Count - 1].Fitness = 0;
                            gnomeIndex--;
                        }
                        else
                            break;
                    }
                }

                if (Genomes[Genomes.Count - 1].Fitness > bestFitness)
                {
                    bestFitness = Genomes[Genomes.Count - 1].Fitness;

                    if (NewBestFitness != null)
                    {
                        GenomeEventArgs args = new GenomeEventArgs();

                        args.Genome = Genomes[Genomes.Count - 1];


                        NewBestFitness(this, args);
                    }
                }

                if (!exitConditions.DoesContinue(this))
                    break;

                for (int g = 0; g < genomeCount; g++)
                {
                    mate[g] = Selector.Select();
                }

                for (int g = 0; g < genomeCount; g++)
                {
                    gnomes[g] = Crossover.Crossover(gnomes[g], mate[g], generations);
                }
            }

            if (!elitism)
                Genomes.Sort();

            return Genomes[Genomes.Count - 1];
        }
    }
}
