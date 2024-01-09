namespace StockExchange.Services.Models.Order
{
    public record OrderPreview(Guid StockId, int NumberOfShares, Guid AccountId);
}
