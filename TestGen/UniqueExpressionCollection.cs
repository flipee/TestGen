using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestGen
{
    public class UniqueExpressionCollection<T1>
    {
        public UniqueExpressionCollection()
        {
            List = new List<UniqueExpression>();
        }
        public List<UniqueExpression> List { get; set; }

        public void AddExpression(string nome, Expression<Func<T1, bool>> expression)
        {
            List.Add(new UniqueExpression(nome, expression));
        }
    }
}
