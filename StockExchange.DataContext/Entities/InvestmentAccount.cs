namespace StockExchange.DataContext.Entities
{
    using StockExchange.DataContext.Abstractions.Entities;
    public class InvestmentAccount : IIdentifiedEntity<Guid>
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public virtual User? User { get; private set; }
        public virtual ICollection<Portfolio> Portfolios { get; private set; } = new List<Portfolio>();
        public decimal CashBalance { get; private set; }

        public InvestmentAccount(Guid userId, decimal cashBalance, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            UserId = userId;
            CashBalance = cashBalance;
        }

        protected InvestmentAccount() { }

        public bool IsEnoughCashBalance(decimal cashBalance, decimal totalCost)
        {
            return cashBalance >= totalCost;
        }

        public void UpdateCashBalance(decimal totalCost)
        {
            CashBalance -= totalCost;
        }
    }
}
