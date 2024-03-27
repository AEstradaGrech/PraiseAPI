using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Specifications;
using System.Linq.Expressions;


namespace PraiseAPI.Infrastructure.Specifications
{
    public class Specification<T> : ISpecification<T> where T : Entity
    {
        protected Expression<Func<T, bool>> _expression;
    
        public Specification() { }
        public Specification(Expression<Func<T, bool>> expression)
        {
            _expression = expression;
        }
        public Expression<Func<T, bool>> Predicate => _expression;

        public virtual Expression<Func<T, bool>> Criteria()
        {
            return _expression;
        }

        public static Specification<T> operator &(Specification<T> leftHand, Specification<T> rightHand)
        {
            InvocationExpression rightInvoke = Expression.Invoke(rightHand.Predicate, leftHand.Predicate.Parameters.Cast<Expression>());

            BinaryExpression newExpression = Expression.MakeBinary(ExpressionType.AndAlso, leftHand.Predicate.Body, rightInvoke);

            return new Specification<T>(Expression.Lambda<Func<T,bool>>(newExpression, leftHand.Predicate.Parameters));
        }

        public static Specification<T> operator |(Specification<T> leftHand, Specification<T> rightHand)
        {
            InvocationExpression rightInvoke = Expression.Invoke(rightHand.Predicate, leftHand.Predicate.Parameters.Cast<Expression>());

            BinaryExpression newExpression = Expression.MakeBinary(ExpressionType.OrElse, leftHand.Predicate.Body, rightInvoke);

            return new Specification<T>(Expression.Lambda<Func<T, bool>>(newExpression, leftHand.Predicate.Parameters));
        }
    }
}
