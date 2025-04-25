using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey> 
    {
        Expression<Func<TEntity, bool>>? Criteria { get; }
        List<Expression<Func<TEntity, Object>>> Includes { get; }
    }
}
// criteria => criteria where 