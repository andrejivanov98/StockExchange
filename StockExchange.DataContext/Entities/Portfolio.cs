namespace StockExchange.DataContext.Entities
{
    using StockExchange.DataContext.Abstractions.Entities;
    public class Portfolio : IIdentifiedEntity<Guid>
    {
        public Guid Id { get; private set; }
        public Guid InvestmentAccountId { get; private set; }
        public Guid StockId { get; private set; }
        public virtual InvestmentAccount? InvestmentAccount { get; private set; }
        public virtual Stock? Stock { get; private set; }
        public int NumberOfShares { get; private set; }

        public Portfolio(Guid accountId, Guid stockId, int numberOfShares, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            InvestmentAccountId = accountId;
            StockId = stockId;
            NumberOfShares = numberOfShares;
        }

        protected Portfolio() { }
    }
}
