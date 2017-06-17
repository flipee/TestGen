using System;
using System.Linq.Expressions;

namespace TestGen
{
    public class UniqueExpression
    {
        public UniqueExpression()
        {

        }
        public UniqueExpression(String nome, LambdaExpression expression)
        {
            Nome = nome;
            Expression = expression;
        }

        public string Nome { get; set; }
        public LambdaExpression Expression { get; set; }
    }
}
