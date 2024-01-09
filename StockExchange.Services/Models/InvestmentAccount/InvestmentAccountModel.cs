namespace StockExchange.Services.Models.InvestmentAccount
{
    using StockExchange.Services.Models.Portfolio;
    public record InvestmentAccountModel(
        Guid Id,
        Guid UserId,
        decimal CashBalance,
        List<PortfolioModel> Portfolio);
}