using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGen
{
    public class ParametersGeneticAlgorithm
    {
        private int qtdNaoRepetirAvaliacao = 0;
        private int idDisciplina = 0;
        private int qtdQuestoes = 0;
        private int tempoPrevistoAvaliacao = 0;
        private bool ignorarTempoMinReutilizacao = false;
        private ConfigComplexidade[] complexRules = null;
        private ConfigTipoQuestao[] tipoQuestaoRules = null;
        List<Questao> questoes = new List<Questao>();
        List<Avaliacao> avaliacoes = null;
        List<AvaliacaoQuestao> questoesAvaliacoes = null;
        List<AvaliacaoAnterior> avaliacoesAnteriores = null;

        int maxDuration = 60;
        int maxGenerations = 4000000;
        double minFitnessGoal = 99.99999995;
        double probabilidadeReproducao = 30;
        double probabilidadeMutacao = 1.5;
        SeletorGA seletor = SeletorGA.Roleta;
        bool habilitaElitismo = true;

        public int QtdNaoRepetirAvaliacao
        {
            get { return qtdNaoRepetirAvaliacao;  }
            set { qtdNaoRepetirAvaliacao = value;  }
        }
        public int IdDisciplina
        {
            get { return idDisciplina; }
            set { idDisciplina = value; }
        }
        public  int QtdQuestoes
        {
            get { return qtdQuestoes;  }
            set { qtdQuestoes = value;  }
        }
        public int TempoPrevistoAvaliacao
        {
            get { return tempoPrevistoAvaliacao; }
            set { tempoPrevistoAvaliacao = value; }
        }

        public bool IgnorarTempoMinReutilizacao
        {
            get { return ignorarTempoMinReutilizacao; }
            set { ignorarTempoMinReutilizacao = value; }
        }
        public ConfigComplexidade[] ComplexRules
        {
            get { return complexRules;  }
            set { complexRules = value; }
        }
        public ConfigTipoQuestao[] TipoQuestaoRules
        {
            get { return tipoQuestaoRules; }
            set { tipoQuestaoRules = value; }
        }
        public List<Questao> Questoes
        {
            get { return questoes; }
            set { questoes = value;  }
        }
        public List<Avaliacao> Avaliacoes
        {
            get { return avaliacoes;  }
            set { avaliacoes = value;  }
        }
        public List<AvaliacaoQuestao> QuestoesAvaliacao
        {
            get { return questoesAvaliacoes;  }
            set { questoesAvaliacoes = value;  }
        }

        public List<AvaliacaoAnterior> AvaliacoesAnteriores
        {
            get { return avaliacoesAnteriores; }
            set { avaliacoesAnteriores = value; }
        }

        public int MaxDuration
        {
            get { return maxDuration;  }
            set { maxDuration = value;  }
        }
        public int MaxGenerations
        {
            get { return maxGenerations; }
            set { maxGenerations = value; }
        }
        public double MinFitnessGoal
        {
            get { return minFitnessGoal; }
            set { minFitnessGoal = value; }
        }
        public double ProbabilidadeReproducao
        {
            get { return probabilidadeReproducao; }
            set { probabilidadeReproducao = value; }
        }
        public double ProbabilidadeMutacao
        {
            get { return probabilidadeMutacao; }
            set { probabilidadeMutacao = value; }
        }
        public SeletorGA Seletor
        {
            get { return seletor; }
            set { seletor = value; }
        }
        public bool HabilitaElitismo
        {
            get { return habilitaElitismo; }
            set { habilitaElitismo = value; }
        }
    }
}
