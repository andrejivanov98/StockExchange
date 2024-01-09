namespace StockExchange.DataContext.Abstractions.Entities
{
    public interface IIdentifiedEntity<T> : IEntity
    {
        T Id { get; }
    }
}
