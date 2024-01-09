namespace StockExchange.Services.Models.Portfolio
{
    using Entity = DataContext.Entities;

    public static class Mappings
    {
        public static PortfolioModel ToModel(this Entity.Portfolio portfolio)
        {
            var stockName = portfolio.Stock?.Name ?? "Unknown";

            return new PortfolioModel(portfolio.Id, portfolio.StockId, stockName, portfolio.NumberOfShares);
        }
    }
}
