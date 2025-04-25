using System.Linq.Expressions;
using Domain.Contracts;
using Domain.Entities;

namespace Service.Specifications
{
    abstract class Specification<TEntity, TKey>(Expression<Func<TEntity, bool>>? criteria = null)
        : ISpecification<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; } = criteria;
        public List<Expression<Func<TEntity, object>>> Includes { get; } = [];

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
            => Includes.Add(includeExpression);
    }   
}
