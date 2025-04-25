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
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDesc { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
            => Includes.Add(includeExpression);
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
            => OrderBy = orderByExpression;
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDescExpression)
            => OrderByDesc = orderByDescExpression;
    }   
}
