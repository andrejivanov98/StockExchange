namespace StockExchange.Services.Models.Order
{
    public record OrderCreate(Guid AccountId, Guid StockId, int NumberOfShares);
}
