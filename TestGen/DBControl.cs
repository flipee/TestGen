using LiteDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TestGen
{
    public static class DBControl
    {
        private static List<LiteTransaction> transactions = new List<LiteTransaction>();

        private static Instituicao instituicao = null;

        public static Instituicao Instituicao
        {
            get { return instituicao; } 
            set { instituicao = value; }
        }

        public static bool CheckInstituicao()
        {
            bool ret = instituicao != null && instituicao.Id > 0;

            if (!ret)
                Mensagem.ShowAlerta(null, "Instituição não configurada!\r\nConfigure primeiro a instituição para utilizar o sistema.");

            return ret;
        }
        public static bool Inicializar()
        {
            bool ret = BaseDados.Open();

            if (ret)
            {
                Table<Professor>.CriarIndice("codigo", false);
                Table<Professor>.CriarIndice("nome", false);

                Table<Curso>.CriarIndice("codigo", false);
                Table<Curso>.CriarIndice("nome", false);

                Table<Disciplina>.CriarIndice("codigo", false);
                Table<Disciplina>.CriarIndice("nome", false);
                Table<Disciplina>.CriarIndice("idcurso", false);
                Table<Disciplina>.CriarIndice("idprofessor", false);

                Table<Questao>.CriarIndice("iddisciplina", false);

                Table<QuestaoItemEscolha>.CriarIndice("idquestao", false);

                Table<QuestaoItemAssociacao>.CriarIndice("idquestao", false);

                Table<Avaliacao>.CriarIndice("iddisciplina", false);
                Table<Avaliacao>.CriarIndice("codigo", false);
                Table<Avaliacao>.CriarIndice("descricao", false);
                Table<Avaliacao>.CriarIndice("dtgeracao", false);

                Table<AvaliacaoQuestao>.CriarIndice("idavaliacao", false);
                Table<AvaliacaoQuestao>.CriarIndice("idquestao", false);
            }

            return ret;
        }

        public static void Finalizar()
        {
            BaseDados.Close();
        }

        public static int BeginTrans()
        {
            LiteTransaction trans = BaseDados.DataBase.BeginTrans();

            transactions.Add(trans);

            return transactions.Count();
        }

        public static int Commit()
        {
            if (transactions.Count > 0)
            {
                int index = transactions.Count() - 1;

                transactions[index].Commit();

                transactions.RemoveAt(index);
            }

            return transactions.Count;
        }

        public static int Rollback()
        {
            if (transactions.Count > 0)
            {
                int index = transactions.Count() - 1;

                transactions[index].Rollback();

                transactions.RemoveAt(index);
            }

            return transactions.Count;
        }
        public static int CommitAll()
        {
            while (transactions.Count > 0)
            {
                transactions[transactions.Count-1].Commit();

                transactions.RemoveAt(transactions.Count - 1);
            }

            return transactions.Count;
        }

        public static int RollbackAll()
        {
            while (transactions.Count > 0)
            {
                transactions[transactions.Count - 1].Rollback();

                transactions.RemoveAt(transactions.Count - 1);
            }

            return transactions.Count;
        }

        public static class Table<T1>
        {
            public static bool CriarIndice(String field, bool unique)
            {
                bool ret = false;

                try
                {
                    var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                    ret = lista.EnsureIndex(field, unique);
                }
                catch (Exception ex)
                {
                    Mensagem.ShowErro("Erro ao criar índice em " + ClassName() + "!", ex);
                }

                return ret;
            }
            public static bool CriarIndice(Expression<Func<T1, bool>> property, bool unique)
            {
                bool ret = false;

                try
                {
                    var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                    ret = lista.EnsureIndex(property, unique);
                }
                catch (Exception ex)
                {
                    Mensagem.ShowErro("Erro ao criar índice em " + ClassName() + "!", ex);
                }

                return ret;
            }

            public static List<T1> Pesquisar()
            {
                List<T1> ret = null;

                try
                {
                    var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                    var results = lista.FindAll();

                    ret = results.ToList<T1>();
                }
                catch (Exception ex)
                {
                    Mensagem.ShowErro("Erro ao pesquisar todos os registros de " + ClassName() + "!", ex);
                }

                return ret;
            }
            public static List<T1> Pesquisar(int id)
            {
                List<T1> ret = null;

                try
                {
                    var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                    var result = lista.FindById(id);

                    ret = new List<T1>();

                    ret.Add(result);
                }
                catch (Exception ex)
                {
                    Mensagem.ShowErro("Erro ao pesquisar registros de " + ClassName() + " por ID!", ex);
                }

                return ret;
            }
            public static List<T1> Pesquisar(Expression predicate)
            {
                return Pesquisar((Expression<Func<T1, bool>>)predicate);
            }

            public static List<T1> Pesquisar(Expression<Func<T1, bool>> predicate)
            {
                List<T1> ret = null;

                try
                {
                    var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                    var results = lista.Find(predicate);

                    ret = results.ToList<T1>();
                }
                catch (Exception ex)
                {
                    Mensagem.ShowErro("Erro ao pesquisar todos os registros de " + ClassName() + "!", ex);
                }

                return ret;
            }

            public static T1 Ler(int id)
            {
                T1 ret = default(T1);

                try
                {
                    var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                    ret = lista.FindById(id);
                }
                catch (Exception ex)
                {
                    Mensagem.ShowErro("Erro ao ler registro de " + ClassName() + "!", ex);
                }

                return ret;
            }
            public static bool Alterar(T1 registro)
            {
                bool ret = false;

                if (registro is Validatable)
                    ret = ((Validatable)registro).Validar();

                if (ret)
                    ret = ValidarAlteracao(registro);

                if (ret)
                {
                    try
                    {
                        var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                        ret = lista.Update(registro);
                    }
                    catch (Exception ex)
                    {
                        Mensagem.ShowErro("Erro ao alterar registro de " + ClassName() + "!", ex);
                    }
                }

                return ret;
            }
            public static int Incluir(T1 registro)
            {
                int id = 0;
                bool valid = true;

                if (registro is Validatable)
                    valid = ((Validatable)registro).Validar();

                if (valid)
                    valid = ValidarInclusao(registro);

                if (valid)
                {
                    try
                    {
                        var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                        id = lista.Insert(registro);
                    }
                    catch (Exception ex)
                    {
                        Mensagem.ShowErro("Erro ao incluir registro em " + ClassName() + "!", ex);
                    }
                }

                return id;
            }

            public static int AutoIncluir(T1 registro)
            {
                int id = 0;
                bool valid = true;

                id = ((IdentityColumn)registro).Id;

                if (registro is Validatable)
                    valid = ((Validatable)registro).Validar();

                if (valid)
                {
                    try
                    {
                        var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                        if (id > 0)
                        {
                            valid = ValidarAlteracao(registro);

                            if (valid)
                                id = lista.Update(registro) ? id : 0;
                        }

                        if (id == 0)
                        {
                            valid = ValidarInclusao(registro);

                            if (valid)
                                id = lista.Insert(registro);
                        }
                    }
                    catch (Exception ex)
                    {
                        Mensagem.ShowErro("Erro ao alterar / incluir registro em " + ClassName() + "!", ex);
                    }
                }

                if (!valid)
                    id = 0;
                
                return id;
            }
            public static bool Excluir(int id)
            {
                bool ret = true;

                T1 registro = Ler(id);

                if (registro != null)
                    ret = Excluir(registro);

                return ret;
            }
            public static bool Excluir(T1 registro)
            {
                bool ret = true;

                if (ret)
                    ret = ValidarExclusao(registro);

                if (ret)
                {
                    try
                    {
                        DBControl.BeginTrans();

                        if (registro is HasAutoRemove)
                        {
                            List<ReferenceExpression> listAR = ((HasAutoRemove)registro).GetAutoRemoveCollection();

                            foreach (ReferenceExpression ar in listAR)
                            {
                                Type clazz = ar.Clazz;

                                Type customListType = typeof(List<>).MakeGenericType(clazz);
                                IList list = (IList)Activator.CreateInstance(customListType);

                                if (ar.Id != 0)
                                    list = Pesquisar(ar.Id);
                                else
                                {
                                    list = InvokePesquisar(clazz, ar.Expression);
                                }

                                if (list != null && list.Count > 0)
                                {
                                    foreach (var item in list)
                                    {
                                        Type clazzMI = typeof(DBControl.Table<>).MakeGenericType(clazz);

                                        var parameterTypes = new object[] { typeof(int) };

                                        MethodInfo mi = clazzMI.GetMethods().FirstOrDefault(m => m.Name == "Excluir" && m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes));

                                        object[] parameters = new object[] { ((IdentityColumn)item).Id };

                                        ret = (bool)mi.Invoke(null, parameters);

                                        if (!ret)
                                            break;
                                    }
                                }
                            }
                        }

                        if (ret)
                        {
                            var lista = BaseDados.DataBase.GetCollection<T1>(CollectionName());

                            ret = lista.Delete(((IdentityColumn)registro).Id);
                        }

                        if (ret)
                            DBControl.Commit();
                        else
                            DBControl.Rollback();
                    }
                    catch (Exception ex)
                    {
                        ret = false;
                        DBControl.Rollback();

                        Mensagem.ShowErro("Erro ao excluir registro de " + ClassName() + "!", ex);
                    }
                }

                return ret;
            }

            private static bool ValidarAlteracao(T1 registro)
            {
                bool ret = true;
                int id = 0;

                if (registro is IdentityColumn)
                    id = ((IdentityColumn)registro).Id;

                if (id > 0)
                {
                    List<UniqueExpression> listUE = null;

                    if (registro is UniqueValidatable)
                        listUE = ((UniqueValidatable)registro).GetUniqueCollection();

                    if (listUE != null)
                    {
                        List<T1> list = null;

                        foreach (UniqueExpression ue in listUE)
                        {
                            list = Pesquisar((Expression<Func<T1, bool>>)ue.Expression);
                            foreach(IdentityColumn reqpesq in list)
                            {
                                ret = reqpesq.Id == id;
                                if (!ret)
                                {
                                    Mensagem.ShowAlerta(null,"Não foi possível efetuar a alteração! Existe outro registro de " + ClassName() + " com o mesmo " + ue.Nome + "!");

                                    break;
                                }
                            }

                            if (!ret)
                                break;
                        }
                    }
                }
                return ret;
            }
            private static bool ValidarInclusao(T1 registro)
            {
                bool ret = true;

                List<UniqueExpression> listUE = null;

                if (registro is UniqueValidatable)
                    listUE = ((UniqueValidatable)registro).GetUniqueCollection();

                if (listUE != null)
                {
                    List<T1> list = null;

                    foreach (UniqueExpression ue in listUE)
                    {
                        list = Pesquisar((Expression<Func<T1, bool>>)ue.Expression);

                        ret = (list.Count<T1>() == 0);

                        if (!ret)
                        {
                            Mensagem.ShowAlerta(null,"Não foi possível efetuar a inclusão! Existe outro registro de " + ClassName() + " com o mesmo " + ue.Nome + "!");
                            break;
                        }
                    }
                }

                return ret;
            }
            private static bool ValidarExclusao(T1 registro)
            {
                bool ret = true;
                int id = 0;

                if (registro is HasReferences)
                    id = ((HasReferences)registro).Id;

                if (id > 0)
                {
                    List<ReferenceExpression> listRE = ((HasReferences)registro).GetReferenceCollection();

                    foreach (ReferenceExpression re in listRE)
                    {
                        Type clazz = re.Clazz;

                        Type customListType = typeof(List<>).MakeGenericType(clazz);
                        IList list = (IList)Activator.CreateInstance(customListType);

                        if (re.Id != 0)
                            list = Pesquisar(re.Id);
                        else
                        {
                            list = InvokePesquisar(clazz,re.Expression);
                        }

                        ret = list.Count == 0;

                        if (!ret)
                        {
                            Mensagem.ShowAlerta(null,"Não foi possível excluir o registro de "+ ClassName()+"! Este registro está sendo referenciado em "+ClassName(clazz)+".");

                            break;
                        }
                    }
                }

                return ret;
            }
            private static String ClassName()
            {
                return typeof(T1).Name;
            }
            private static String ClassName(Type clazz)
            {
                return clazz.Name;
            }

            private static String CollectionName()
            {
                return (typeof(T1).Name + "_col").ToLower();
            }

            private static IList InvokePesquisar(Type clazz, Expression expression)
            {

                var typeFunc = typeof(Func<,>);
                var genericTypeFunc = typeFunc.MakeGenericType(clazz, typeof(bool));
                var typeExpression = typeof(Expression<>);
                var genericTypeExpression = typeExpression.MakeGenericType(genericTypeFunc);

                var expressionConv = Convert.ChangeType(expression, genericTypeExpression);

                Type clazzMI = typeof(DBControl.Table<>).MakeGenericType(clazz);

                var parameterTypes = new object[] { typeof(Expression) };

                MethodInfo mi = clazzMI.GetMethods().FirstOrDefault(m => m.Name == "Pesquisar" && m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes));

                object[] parameters = new object[] { expressionConv };

                return (IList) mi.Invoke(null, parameters);
            }
        }
    }
}
