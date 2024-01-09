namespace StockExchange.Services.Models.Portfolio
{
    public record PortfolioModel(Guid Id, Guid StockId, string StockName, int NumberOfShares);
}
