using System;
using System.ComponentModel;
using TestGen.GeneticAlgorithms;

namespace TestGen
{
    public enum SeletorGA
    {
        NaoEspecificado = 0,
        Roleta = 1,
        Sequencial = 2,
        Randomico = 3
    }

    public delegate void ProcessGeneticAlgorithmGenerationEventHandler(ProcessGeneticAlgorithm sender, GenerationEventArgs args);
    public delegate void ProcessGeneticAlgorithmCustomGenomeEventHandler(ProcessGeneticAlgorithm sender, CustomGenomeEventArgs args);

    public class CustomGenomeEventArgs : EventArgs
    {
        public CustomGenome Genome { get; set; }
    }
    public class GenerationEventArgs : EventArgs
    {
        public int Generation { get; set; }
    }
    public class ProcessGeneticAlgorithm
    {
        GeneticAlgorithm ga = new GeneticAlgorithm();
        ParametersGeneticAlgorithm parameters;
        ExitCondictionType exitCondiction = ExitCondictionType.None;

        CustomGenome bestGenome = null;

        DateTime stopTime;

        public event ProcessGeneticAlgorithmGenerationEventHandler OnGANewGeneration;
        public event ProcessGeneticAlgorithmCustomGenomeEventHandler OnGANewBestFitness;

        public ProcessGeneticAlgorithm(ParametersGeneticAlgorithm parameters)
        {
            this.parameters = parameters;
        }

        public DateTime StartTime
        {
            get { return ga.StartTime; }
        }

        public DateTime StopTime
        {
            get { return stopTime;  }
        }

        public double ElapTimeSeconds
        {
            get { return (stopTime - ga.StartTime).TotalSeconds;  }
        }
        public ExitCondictionType ExitCondiction
        {
            get { return exitCondiction; }
        }

        public CustomGenome BestGenome
        {
            get { return bestGenome; }
        }

        public int GenerationCount
        {
            get { return ga.GenerationCount; }
        }

        public void StopProcess()
        {
            ga.ExitConditions.StopProcess();
        }

        public bool Execute()
        {
            ga.Crossover = new CustomCrossover();
            ga.GenomeFactory = new CustomFactory(0, parameters.Questoes.Count-1, parameters.QtdQuestoes);

            switch (parameters.Seletor)
            {
                case SeletorGA.Roleta:
                    ga.Selector = new WeightedSelector(ga.Genomes);
                    break;
                case SeletorGA.Sequencial:
                    ga.Selector = new SequentialSelector(ga.Genomes);
                    break;
                case SeletorGA.Randomico:
                    ga.Selector = new RandomSelector(ga.Genomes);
                    break;
            }

            ga.Crossover.CrossoverProbability = parameters.ProbabilidadeReproducao/100.0; //0.3;0.2;
            ga.Crossover.MutationProbability = parameters.ProbabilidadeMutacao/100.0; //0.015;
            ga.Elitism = parameters.HabilitaElitismo;

            ga.CustomObj = parameters.Questoes;

            if (OnGANewGeneration!=null)
                ga.NewGeneration += new GeneticAlgorithmEventHandler(this.OnNewGeneration);

            if (OnGANewBestFitness!=null)
                ga.NewBestFitness += new GeneticAlgorithmGenomeEventHandler(this.OnNewBestFitness);

            ga.QryBestFitness += new GeneticAlgorithmCancelEventHandler(this.OnQryBestFitness);

            ga.Evaluator = new CustomEvaluator(parameters);

            ga.CreateGenomes(9);

            ga.ExitConditions.Duration = TimeSpan.FromSeconds(parameters.MaxDuration);
            ga.ExitConditions.Generations = parameters.MaxGenerations;
            ga.ExitConditions.FitnessGoal = parameters.MinFitnessGoal;

            bestGenome = (CustomGenome)ga.Execute();

            stopTime = DateTime.Now;

            exitCondiction = ga.ExitConditions.ExitCondiction;

            bestGenome.UpdateStat(parameters);

            return true;
        }

        public void OnNewGeneration(GeneticAlgorithm sender, EventArgs args)
        {
            if (OnGANewGeneration != null)
            {
                GenerationEventArgs newArgs = new GenerationEventArgs();

                newArgs.Generation = sender.GenerationCount;

                OnGANewGeneration(this, newArgs);
            }
        }

        public void OnNewBestFitness(GeneticAlgorithm sender, GenomeEventArgs args)
        {
            CustomGenome genome = (CustomGenome)args.Genome;

            genome.UpdateStat(parameters);

            //int hash = genome.GetHashCode();

            if (OnGANewBestFitness != null)
            {
                CustomGenomeEventArgs newArgs = new CustomGenomeEventArgs();

                newArgs.Genome = genome;

                OnGANewBestFitness(this, newArgs);
            }
        }

        public void OnQryBestFitness(GeneticAlgorithm sender, GenomeCancelEventArgs args)
        {
            CustomGenome genomeCustom = (CustomGenome)args.Genome;

            String key = genomeCustom.ToOrderedString();

            AvaliacaoAnterior a = parameters.AvaliacoesAnteriores.Find(x => x.Key.Equals(key));

            if (genomeCustom.QtdTotal() != parameters.QtdQuestoes || ( a != null && (DateTime.Today-a.DtUtilizacao).Days <= parameters.QtdNaoRepetirAvaliacao))
            {
                args.Cancel = true;
            }
        }
    }
}

