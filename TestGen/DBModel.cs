using System;
using System.Collections.Generic;

namespace TestGen
{
    public enum TipoDeQuestao
    {
        NaoSelecionado=0,
        Discursiva=1,
        EscolhaSimples=2,
        MultiplaEscolha=3,
        ListaDeAssociacao=4
    }

    public interface IdentityColumn
    {
        int Id { get; set; }
    }
    public interface HasReferences : IdentityColumn
    {
        List<ReferenceExpression> GetReferenceCollection();
    }
    public interface HasAutoRemove : IdentityColumn
    {
        List<ReferenceExpression> GetAutoRemoveCollection();
    }
    public interface Ativable
    {
        bool Ativo { get; set; }
    }
    public interface Nameable
    {
        string Nome { get; set; }
    }
    public interface Validatable
    {
        bool Validar();
    }
    public interface UniqueValidatable
    {
        List<UniqueExpression> GetUniqueCollection();
    }

    public class Instituicao : IdentityColumn, Nameable, Validatable, UniqueValidatable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Logotipo { get; set; }
        public int QtdNaoRepetirAvaliacao { get; set; }
        public int QtdQuestoesAvaliacao { get; set; }

        public bool Validar()
        {
            bool ret=true;

            if (ret)
            {
                ret = !Nome.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Nome não fornecido!");
            }

            if (ret)
            {
                ret = QtdNaoRepetirAvaliacao > 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Quantidade de dias para repetir questões nas avaliações deve ser maior que zero!");
            }

            if (ret)
            {
                ret = QtdNaoRepetirAvaliacao < 1000;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Quantidade de dias para repetir questões nas avaliações deve ser inferior a 1000!");
            }

            if (ret)
            {
                ret = QtdQuestoesAvaliacao >= 5;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Quantidade de questões na avaliação deve ser maior ou itual a 5!");
            }

            if (ret)
            {
                ret = QtdQuestoesAvaliacao <=100;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Quantidade de questões na avaliação deve ser menor ou igual a 100!");
            }

            return ret;
        }
        public List<UniqueExpression> GetUniqueCollection()
        {
            UniqueExpressionCollection<Instituicao> UElist = new UniqueExpressionCollection<Instituicao>();

            UElist.AddExpression("Nome",x => x.Nome.Equals(Nome));

            return UElist.List;
        }
    }
    public class Professor : IdentityColumn, HasReferences, Nameable, Ativable,Validatable, UniqueValidatable
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public bool Validar()
        {
            bool ret = true;

            if (ret)
            {
                ret = !Codigo.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Código não fornecido!");
            }

            if (ret)
            {
                ret = !Nome.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Nome não fornecido!");
            }

            if (ret)
            {
                ret = !Email.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"E-mail não fornecido!");
            }

            if (ret)
            {
                ret = Validacoes.ValidarEmail(Email);
                if (!ret)
                    Mensagem.ShowAlerta(null,"E-mail inválido!");
            }
            return ret;
        }
        public List<UniqueExpression> GetUniqueCollection()
        {
            UniqueExpressionCollection<Professor> UElist = new UniqueExpressionCollection<Professor>();

            UElist.AddExpression("Codigo",x => x.Codigo.Equals(Codigo));
            UElist.AddExpression("Nome",x => x.Nome.Equals(Nome));
            UElist.AddExpression("Email",x => x.Email.Equals(Email));

            return UElist.List;
        }

        public List<ReferenceExpression> GetReferenceCollection()
        {
            ReferenceExpressionCollection RElist = new ReferenceExpressionCollection();

            RElist.AddExpression<Disciplina>(x => x.IdProfessor==Id);

            return RElist.List;
        }
    }
    public class Curso : IdentityColumn, HasReferences, Nameable, Ativable,Validatable, UniqueValidatable
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public bool Validar()
        {
            bool ret = true;

            if (ret)
            {
                ret = !Codigo.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Código não fornecido!");
            }

            if (ret)
            {
                ret = !Nome.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Nome não fornecido!");
            }

            return ret;
        }

        public List<UniqueExpression> GetUniqueCollection()
        {
            UniqueExpressionCollection<Curso> UElist = new UniqueExpressionCollection<Curso>();

            UElist.AddExpression("Codigo",x => x.Codigo.Equals(Codigo));
            UElist.AddExpression("Nome",x => x.Nome.Equals(Nome));

            return UElist.List;
        }
        public List<ReferenceExpression> GetReferenceCollection()
        {
            ReferenceExpressionCollection RElist = new ReferenceExpressionCollection();

            RElist.AddExpression<Disciplina>(x => x.IdCurso == Id);

            return RElist.List;
        }
    }
    public class Disciplina : IdentityColumn, HasReferences, HasAutoRemove, Nameable, Ativable,Validatable, UniqueValidatable
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int IdCurso { get; set; }
        public int IdProfessor { get; set; }
        public bool Ativo { get; set; }
        public bool Validar()
        {
            bool ret = true;

            if (ret)
            {
                ret = !Codigo.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Código não fornecido!");
            }

            if (ret)
            {
                ret = !Nome.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Nome não fornecido!");
            }

            if (ret)
            {
                ret = IdCurso != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Curso não foi selecionado!");
            }

            if (ret)
            {
                ret = IdProfessor != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Professor não foi selecionado!");
            }

            return ret;
        }
        public List<UniqueExpression> GetUniqueCollection()
        {
            UniqueExpressionCollection<Disciplina> UElist = new UniqueExpressionCollection<Disciplina>();

            UElist.AddExpression("Codigo",x => x.Codigo.Equals(Codigo));
            UElist.AddExpression("Nome",x => x.Nome.Equals(Nome));

            return UElist.List;
        }
        public List<ReferenceExpression> GetReferenceCollection()
        {
            ReferenceExpressionCollection RElist = new ReferenceExpressionCollection();

            RElist.AddExpression<Questao>(x => x.IdDisciplina == Id);

            return RElist.List;
        }
        public List<ReferenceExpression> GetAutoRemoveCollection()
        {
            ReferenceExpressionCollection RElist = new ReferenceExpressionCollection();

            RElist.AddExpression<GeracaoAvaliacao>(x => x.IdDisciplina == Id);

            return RElist.List;
        }
    }
    public class Questao : IdentityColumn, Ativable, HasReferences, Validatable
    {
        public int Id { get; set; }
        public int IdDisciplina { get; set; }
        public TipoDeQuestao TipoQuestao { get; set; }
        public int Complexidade { get; set; }
        public int TempoResposta { get; set; }
        public string Enunciado { get; set; }
        public byte[] Imagem { get; set; }
        public int QtdLinhasEnunciado { get; set; }
        public int QtdLinhasResposta { get; set; }
        public int TempoMinimoReutilizacao { get; set; }
        public string SequenciaImpressao { get; set; }
        public bool Ativo { get; set; }
        public bool Validar()
        {
            bool ret = true;
            
            if (ret)
            {
                ret = IdDisciplina != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Disciplina não foi selecionada!");
            }

            if (ret)
            {
                ret = TipoQuestao != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Tipo da Questão não foi selecionado!");
            }

            if (ret)
            {
                ret = Complexidade != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Complexidade não foi fornecida!");
            }

            if (ret)
            {
                ret = Complexidade >= 1 && Complexidade <= 10;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Complexidade inválida! Utilize um número de 1 a 10!");
            }

            if (ret)
            {
                ret = TempoResposta != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Tempo de Resposta não fornecido!");
            }

            if (ret)
            {
                ret = TempoResposta >=1 && TempoResposta <= 360;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Tempo de Resposta inválido! Utilize um número de 1 a 360 segundos!");
            }

            if (ret)
            {
                ret = !Enunciado.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Enunciado não fornecido!");
            }

            if (ret)
            {
                ret = QtdLinhasEnunciado != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Quantidade de linhas do Enunciado não foi fornecida!");
            }

            if (ret)
            {
                ret = QtdLinhasEnunciado >= 1 && QtdLinhasEnunciado <= 20;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Quantidade de linhas do Enunciado inválida! Utilize um número de 1 a 20 linhas!");
            }

            if (ret && TipoQuestao == TipoDeQuestao.Discursiva)
            {
                if (ret)
                {
                    ret = QtdLinhasResposta != 0;
                    if (!ret)
                        Mensagem.ShowAlerta(null,"Quantidade de linhas da resposta não foi fornecida!");
                }

                if (ret)
                {
                    ret = QtdLinhasResposta >= 1 && QtdLinhasResposta <= 20;
                    if (!ret)
                        Mensagem.ShowAlerta(null,"Quantidade de linhas da resposta inválida! Utilize um número de 1 a 20 linhas!");
                }
            }

            if (ret)
            {
                ret = TempoMinimoReutilizacao != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Tempo mínimo de reutilização não fornecido!");
            }

            if (ret)
            {
                ret = TempoMinimoReutilizacao >= 1 && TempoMinimoReutilizacao <= 9999;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Tempo mínimo de reutilização inválido! Utilize um número de 0 e 9999 dias!");
            }

            if (ret)
            {
                ret = TempoResposta != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Tempo de resposta não fornecido!");
            }

            if (ret)
            {
                ret = TempoResposta >= 1 && TempoResposta <= 999;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Tempo de resposta inválido! Utilize um número de 0 e 999 segundos!");
            }

            if (ret)
            {
                ret = !SequenciaImpressao.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Sequência de Impressão não foi fornecida!");
            }
            
            if (ret)
            {
                ret = ValidaSequenciaImpressao(SequenciaImpressao);
            }

            return ret;
        }

        private bool ValidaSequenciaImpressao(string sequencia)
        {
            //E=Enunciado,I=Imagem,L=Lista de Itens,A=Lista de Associação,R=Resposta

            string strvld = "";

            switch (TipoQuestao)
            {
                case TipoDeQuestao.Discursiva:
                    strvld="EIR";
                    break;
                case TipoDeQuestao.EscolhaSimples:
                    strvld = "EIL";
                    break;
                case TipoDeQuestao.MultiplaEscolha:
                    strvld = "EIL";
                    break;
                case TipoDeQuestao.ListaDeAssociacao:
                    strvld = "ELA";
                    break;
            }

            bool ret = ValidaSequencia(sequencia, strvld);

            if (!ret)
                Mensagem.ShowAlerta(null,"Sequência de Impressão inválida!");
            else
            {
                if (Imagem == null)
                {
                    ret = !sequencia.Contains("I");
                    if (!ret)
                        Mensagem.ShowAlerta(null,"Sequência de Impressão indica utilização de imágem, mas, não há imagem definida!");
                }
                else
                {
                    ret = sequencia.Contains("I");
                    if (!ret)
                        Mensagem.ShowAlerta(null,"Sequência de Impressão não indica utilização de imágem, mas, há imagem definida!");
                }
            }

            return ret;
        }

        private bool ValidaSequencia(string sequencia, string strvld)
        {
            bool ret = true;

            foreach(char ch in sequencia)
            {
                ret = strvld.Contains(ch.ToString());

                if (!ret)
                    break;
            }

            return ret;
        }
        public List<ReferenceExpression> GetReferenceCollection()
        {
            ReferenceExpressionCollection RElist = new ReferenceExpressionCollection();

            RElist.AddExpression<QuestaoItemEscolha>(x => x.IdQuestao == Id);
            RElist.AddExpression<QuestaoItemAssociacao>(x => x.IdQuestao == Id);
            RElist.AddExpression<AvaliacaoQuestao>(x => x.IdQuestao == Id);

            return RElist.List;
        }
    }

    public class QuestaoItemEscolha : IdentityColumn, Validatable
    {
        public int Id { get; set; }
        public int IdQuestao { get; set; }
        public string Descricao { get; set; }
        public int QtdLinhasOcupadas { get; set; }
        public bool Validar()
        {
            bool ret = true;

            if (ret)
            {
                ret = !Descricao.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Descrição do item de escolha não fornecida!");
            }

            if (ret)
            {
                ret = QtdLinhasOcupadas != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Qtd. Linhas Ocupadas do item de escolha não fornecida ou inválida!");
            }

            return ret;
        }
    }
    public class QuestaoItemAssociacao : IdentityColumn, Validatable
    {
        public int Id { get; set; }
        public int IdQuestao { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public int QtdLinhasOcupadas { get; set; }
        public bool Validar()
        {
            bool ret = true;

            if (ret)
            {
                ret = !Codigo.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Código do item de associação não fornecido!");
            }

            if (ret)
            {
                ret = !Descricao.Equals("");
                if (!ret)
                    Mensagem.ShowAlerta(null,"Descrição do item de associação não fornecida!");
            }

            if (ret)
            {
                ret = QtdLinhasOcupadas != 0;
                if (!ret)
                    Mensagem.ShowAlerta(null,"Qtd. Linhas Ocupadas do item de associação não fornecida ou inválida!");
            }

            return ret;
        }
    }
    public class Avaliacao : IdentityColumn, HasReferences, UniqueValidatable
    {
        public int Id { get; set; }
        public int IdDisciplina { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int QtdQuestoes { get; set; }
        public DateTime DtGeracao { get; set; }

        public List<ReferenceExpression> GetReferenceCollection()
        {
            ReferenceExpressionCollection RElist = new ReferenceExpressionCollection();

            RElist.AddExpression<AvaliacaoQuestao>(x => x.IdAvaliacao == Id);

            return RElist.List;
        }

        public List<UniqueExpression> GetUniqueCollection()
        {
            UniqueExpressionCollection<Avaliacao> UElist = new UniqueExpressionCollection<Avaliacao>();

            UElist.AddExpression("Codigo", x => x.Codigo.Equals(Codigo));

            return UElist.List;
        }

    }
    public class AvaliacaoQuestao : IdentityColumn
    {
        public int Id { get; set; }
        public int IdAvaliacao { get; set; }
        public int IdQuestao { get; set; }
        public DateTime DtGeracao { get; set; }
    }

    public class ConfigComplexidade
    {
        public int Index { get; set; }
        public int ComplexIni { get; set; }
        public int ComplexFim { get; set; }
        public int Quantidade { get; set; }
    }

    public class ConfigTipoQuestao
    {
        public int Index { get; set; }
        public TipoDeQuestao TipoQuestao { get; set; }
        public bool Ativo { get; set; }
        public int Quantidade { get; set; }
    }

    public class GeracaoAvaliacao : IdentityColumn
    {
        public int Id { get; set; }
        public int IdDisciplina { get; set; }
        public int QtdQuestoesAvaliacao { get; set; }
        public int TempoPrevistoResposta { get; set; }
        public bool IgnorarTempoMinReutilizacao { get; set; }
        public int TempoMaximoProc { get; set; }
        public int QtdMaxGeracoes { get; set; }
        public double PercMinAceitavel { get; set; }
        public double ProbabilidadeReproducao { get; set; }
        public double ProbabilidadeMutacao { get; set; }
        public SeletorGA Seletor { get; set; }
        public bool HabilitaElitismo { get; set; }
        public ConfigTipoQuestao[] ConfigTipoQuestoes { get; set; }
        public ConfigComplexidade[] ConfigComplexidades { get; set; }
        public bool ConfigEquals(GeracaoAvaliacao geracaoAvaliacao)
        {
            bool ret = IdDisciplina == geracaoAvaliacao.IdDisciplina;

            if (ret)
                ret = QtdQuestoesAvaliacao == geracaoAvaliacao.QtdQuestoesAvaliacao;

            if (ret)
                ret = TempoPrevistoResposta == geracaoAvaliacao.TempoPrevistoResposta;

            if (ret)
                ret = TempoMaximoProc == geracaoAvaliacao.TempoMaximoProc;

            if (ret)
                ret = IgnorarTempoMinReutilizacao == geracaoAvaliacao.IgnorarTempoMinReutilizacao;

            if (ret)
                ret = QtdMaxGeracoes == geracaoAvaliacao.QtdMaxGeracoes;

            if (ret)
                ret = PercMinAceitavel == geracaoAvaliacao.PercMinAceitavel;

            if (ret)
                ret = ProbabilidadeReproducao == geracaoAvaliacao.ProbabilidadeReproducao;

            if (ret)
                ret = ProbabilidadeMutacao == geracaoAvaliacao.ProbabilidadeMutacao;

            if (ret)
                ret = Seletor == geracaoAvaliacao.Seletor;

            if (ret)
                ret = HabilitaElitismo == geracaoAvaliacao.HabilitaElitismo;

            if (ret)
                ret = geracaoAvaliacao.ConfigComplexidades!=null && ConfigComplexidades.Length == geracaoAvaliacao.ConfigComplexidades.Length;

            if (ret)
                ret = geracaoAvaliacao.ConfigTipoQuestoes!=null && ConfigTipoQuestoes.Length == geracaoAvaliacao.ConfigTipoQuestoes.Length;

            if (ret)
            {
                for (int index = 0; index < ConfigComplexidades.Length; index++)
                {
                    ret = ConfigComplexidades[index].Index == geracaoAvaliacao.ConfigComplexidades[index].Index;

                    if (ret)
                        ret = ConfigComplexidades[index].ComplexIni == geracaoAvaliacao.ConfigComplexidades[index].ComplexIni;

                    if (ret)
                        ret = ConfigComplexidades[index].ComplexFim == geracaoAvaliacao.ConfigComplexidades[index].ComplexFim;

                    if (ret)
                        ret = ConfigComplexidades[index].Quantidade == geracaoAvaliacao.ConfigComplexidades[index].Quantidade;

                    if (!ret)
                        break;
                }
            }

            if (ret)
            {
                for (int index = 0; index < ConfigTipoQuestoes.Length; index++)
                {
                    ret = ConfigTipoQuestoes[index].Index == geracaoAvaliacao.ConfigTipoQuestoes[index].Index;

                    if (ret)
                        ret = ConfigTipoQuestoes[index].TipoQuestao == geracaoAvaliacao.ConfigTipoQuestoes[index].TipoQuestao;

                    if (ret)
                        ret = ConfigTipoQuestoes[index].Ativo == geracaoAvaliacao.ConfigTipoQuestoes[index].Ativo;

                    if (ret)
                        ret = ConfigTipoQuestoes[index].Quantidade == geracaoAvaliacao.ConfigTipoQuestoes[index].Quantidade;

                    if (!ret)
                        break;
                }
            }

            return ret;
        }
    }

    public class QuestaoUtilizacao
    {
        public int IdQuestao { get; set; }
        public DateTime DtUtilizacao { get; set; }
    }

    public class AvaliacaoAnterior
    {
        public int IdAvaliacao { get; set; }
        public DateTime DtUtilizacao { get; set; }
        public string Key { get; set; }
        public int HashCode { get; set; }
        public List<int> Questoes { get; set; }
    }
}
