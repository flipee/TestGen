using LiteDB;
using System;
using System.Diagnostics;
using System.Text;

namespace TestGen
{
    class BaseDados
    {
        private static LiteDatabase db = null;

        public static LiteDatabase DataBase
        {
            get { return db; }
        }
        public static bool Open()
        {
            String dbName = Process.GetCurrentProcess().MainModule.FileName.ToUpper().Replace(".EXE", ".DB");

            dbName = System.IO.Path.GetFileName(dbName);

            StringBuilder sb = new StringBuilder();

            sb.Append(Environment.CurrentDirectory);
            sb.Append("\\");
            sb.Append(dbName);

            string arquivo = sb.ToString().Replace("\\\\", "\\");

            return Open(arquivo);
        }
        public static bool Open(String NomeArquivo)
        {
            bool ret = false;

            try
            {
                if (db == null)
                  db = new LiteDatabase(NomeArquivo);

                ret = true;
            }
            catch (Exception ex)
            {
                Mensagem.ShowErro("Erro ao abrir a base de dados!", ex);
            }

            return ret;
        }

        public static void Close()
        {
            db = null;
        }
    }
}
