using System;
using System.Linq;
using System.Linq.Expressions;

namespace HelperModule
{
    public class CustomExpretionVisitor<TTo, TFrom>: ExpressionVisitor
    {
        private ParameterExpression parameter;

        public CustomExpretionVisitor(ParameterExpression parameter)
        {
            this.parameter = parameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return parameter;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TFrom))
                return Expression.MakeMemberAccess(this.Visit(node.Expression),
                   typeof(TTo).GetMember(node.Member.Name).FirstOrDefault());
            return base.VisitMember(node);
        }

        public static Expression<Func<TTo, bool>> Tranform(Expression<Func<TFrom, bool>> expression)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TTo), expression.Parameters[0].Name);
            Expression body = new CustomExpretionVisitor<TTo, TFrom>(parameter).Visit(expression.Body);
            return Expression.Lambda<Func<TTo, bool>>(body, parameter);
        }
    }
}
