using Persistence.Data;

namespace Persistence.Repositories
{
    internal class GenericRepository<TEntity, TKey> (AppDbContext dbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await dbContext.Set<TEntity>().ToListAsync();
        

        public async Task<TEntity?> GetByIdAsync(TKey id)
        => await dbContext.Set<TEntity>().FindAsync(id);
        

        public async Task AddAsync(TEntity entity)
        => await dbContext.Set<TEntity>().AddAsync(entity);

        public void UpdateAsync(TEntity entity)
        => dbContext.Set<TEntity>().Update(entity);

        public void DeleteAsync(TEntity entity)
            => dbContext.Set<TEntity>().Remove(entity);
    }
}
