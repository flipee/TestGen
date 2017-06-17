using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestGen
{
    public class ReferenceExpressionCollection
    {
        public ReferenceExpressionCollection()
        {
            List = new List<ReferenceExpression>();
        }
        public List<ReferenceExpression> List { get; set; }

        public void AddId<T1>(int id)
        {
            Type clazz = typeof(T1);

            List.Add(new ReferenceExpression(clazz, id));
        }
        public void AddExpression<T1>(Expression<Func<T1, bool>> expression)
        {
            Type clazz = typeof(T1);

            List.Add(new ReferenceExpression(clazz, expression));
        }
    }

}
