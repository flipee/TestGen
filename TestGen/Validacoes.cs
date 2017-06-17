using System.Text.RegularExpressions;

namespace TestGen
{
    public static class Validacoes
    {
        public static bool ValidarEmail(string email)
        {
            bool valido = false;

            string emailRegex = string.Format("{0}{1}",
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            try
            {
                valido = Regex.IsMatch(email, emailRegex);
            }
            catch (RegexMatchTimeoutException)
            {
                valido = false;
            }

            return valido;
        }
    }
}
