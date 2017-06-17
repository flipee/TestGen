using System;
using System.Text;
using System.Windows.Forms;

namespace TestGen
{
    public static class Mensagem
    {
        public static void ShowErro(String mensagem, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(mensagem);
            sb.Append("\n");
            sb.Append("Deseja visualizar a origem do erro?");

            if (MessageBox.Show(sb.ToString(), "Erro!", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK);
            }
        }
        public static void ShowAlerta(IWin32Window owner, String mensagem)
        {
            MessageBox.Show(owner,mensagem, "Atenção!", MessageBoxButtons.OK);
        }
        public static DialogResult ShowPerguntaSimNao(IWin32Window owner, String mensagem)
        {
            return MessageBox.Show(owner,mensagem, "Questão!", MessageBoxButtons.YesNo);
        }
        public static DialogResult ShowPerguntaSimNaoCancel(IWin32Window owner, String mensagem)
        {
            return MessageBox.Show(owner,mensagem, "Questão!", MessageBoxButtons.YesNoCancel);
        }

        public static void ShowNaoImplementado(IWin32Window owner)
        {
            MessageBox.Show(owner,"Rotina não implementada!", "Atenção!", MessageBoxButtons.OK);
        }
    }
}
