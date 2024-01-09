namespace StockExchange.Services.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using StockExchange.DataContext;
    using StockExchange.DataContext.Abstractions.Entities;
    using StockExchange.Services.Abstractions.Repositories;

    public class Repository<T> : IRepository<T> 
        where T : class, IEntity, IIdentifiedEntity<Guid>
    {
        private readonly StockExchangeContext _context;
        private readonly DbSet<T> _entities;

        public Repository(StockExchangeContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
