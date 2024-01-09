namespace StockExchange.DataContext.Abstractions.Entities
{
    public interface INamedEntity : IEntity
    {
        Guid Id { get; }

        string Name { get; }
    }
}
