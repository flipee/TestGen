using System;

namespace TestGen.GeneticAlgorithms
{
    public enum ExitCondictionType
    {
        None,
        Overtime,
        OverGenerationCount,
        FitnessGoal,
        Stopped
    }
	public class ExitConditions
	{
        private ExitCondictionType exitCondiction = ExitCondictionType.None;
        private TimeSpan duration = new TimeSpan(long.MaxValue);
        private int generations = int.MaxValue;
        private double fitnessGoal = double.MaxValue;
        private bool stopProcess = false;
        public ExitConditions()
		{

		}
		public virtual bool DoesContinue(GeneticAlgorithm gaToEvaluate)
		{
            DateTime now = DateTime.Now;

            bool ret=true;

            lock (this)
            {
                ret = (!stopProcess)
                        && (now - gaToEvaluate.StartTime) < Duration
                        && gaToEvaluate.GenerationCount < Generations
                        && gaToEvaluate.Genomes[gaToEvaluate.Genomes.Count - 1].Fitness < FitnessGoal;
            }

            if (!ret)
            {
                if (stopProcess)
                    exitCondiction = ExitCondictionType.Stopped;
                else if (gaToEvaluate.Genomes[gaToEvaluate.Genomes.Count - 1].Fitness >= FitnessGoal)
                    exitCondiction = ExitCondictionType.FitnessGoal;
                else if ((now - gaToEvaluate.StartTime) >= Duration)
                    exitCondiction = ExitCondictionType.Overtime;
                else if (gaToEvaluate.GenerationCount >= Generations)
                    exitCondiction = ExitCondictionType.OverGenerationCount;
            }

            return ret;
		}

        public ExitCondictionType ExitCondiction
        {
            get { return exitCondiction;  }
        }

        public virtual TimeSpan Duration
		{
			get { return duration; }
			set { duration=value; }
		}

		public virtual int Generations
		{
			get { return generations; }
			set { generations=value; }
		}
		public virtual double FitnessGoal
		{
			get { return fitnessGoal; }
			set { fitnessGoal=value; }
		}

        public virtual void StopProcess()
        {
            lock (this)
            {
                stopProcess = true;
            }
        }
    }
}
