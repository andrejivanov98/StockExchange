namespace StockExchange.Services.Models.Order
{
    public record OrderPreviewModel(Guid StockId, string StockName, int NumberOfShares, decimal TotalCost, bool isOrderValid);
}
