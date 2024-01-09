namespace StockExchange.DataContext.Entities
{
    using StockExchange.DataContext.Abstractions.Entities;
    public class Stock : IIdentifiedEntity<Guid>, INamedEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal CurrentPrice { get; private set; }
        public virtual ICollection<Portfolio> Portfolios { get; private set; } = new List<Portfolio>();

        public Stock(string name, decimal currentPrice, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            CurrentPrice = currentPrice;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Stock() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
