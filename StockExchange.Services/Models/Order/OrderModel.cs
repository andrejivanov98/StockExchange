namespace StockExchange.Services.Models.Order
{
    public record OrderModel(
        Guid Id,
        Guid AccountId,
        Guid StockId,
        string StockName,
        int NumberOfShares,
        decimal TotalCost,
        decimal UpdatedCashBalance);
}