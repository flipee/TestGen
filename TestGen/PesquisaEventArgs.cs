using System;

namespace TestGen
{
    public enum TipoDaPesquisa
    {
        Nenhum,
        PorCodigo,
        PorNome,
        Todos
    }

    public class PesquisaEventArgs : EventArgs
    {
        private readonly TipoDaPesquisa tipopesquisa;
        private readonly String pesquisa;

        public PesquisaEventArgs(TipoDaPesquisa tp, String pesq)
        {
            tipopesquisa = tp;
            pesquisa = pesq;
        }

        public TipoDaPesquisa TipoPesquisa { get { return tipopesquisa; } }
        public string Pesquisa { get { return pesquisa; } }
    }
}
