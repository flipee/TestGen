using System;
using System.Linq.Expressions;

namespace TestGen
{
    public class ReferenceExpression
    {
        public ReferenceExpression()
        {

        }
        public ReferenceExpression(Type clazz, int id)
        {
            Clazz = clazz;
            Id = id;
            Expression = null;
        }
        public ReferenceExpression(Type clazz, LambdaExpression expression)
        {
            Clazz = clazz;
            Id = 0;
            Expression = expression;
        }
        public Type Clazz { get; set; }
        public int Id { get; set; }
        public LambdaExpression Expression { get; set; }

    }
}
