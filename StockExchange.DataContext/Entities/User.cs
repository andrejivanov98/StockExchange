namespace StockExchange.DataContext.Entities
{
    using StockExchange.DataContext.Abstractions.Entities;
    public class User : IIdentifiedEntity<Guid>, INamedEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public virtual InvestmentAccount? InvestmentAccount { get; private set; }

        public User(string name, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected User() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void AddInvestmentAccount(InvestmentAccount investmentAccount)
        {
            InvestmentAccount = investmentAccount ?? throw new ArgumentNullException(nameof(investmentAccount));
        }
    }
}
