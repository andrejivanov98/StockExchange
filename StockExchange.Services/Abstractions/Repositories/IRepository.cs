namespace StockExchange.Services.Abstractions.Repositories
{
    using StockExchange.DataContext.Abstractions.Entities;
    public interface IRepository<T> 
        where T : class, IEntity, IIdentifiedEntity<Guid>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
