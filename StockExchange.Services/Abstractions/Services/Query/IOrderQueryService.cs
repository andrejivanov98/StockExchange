namespace StockExchange.Services.Abstractions.Services.Query
{
    using StockExchange.Services.Models.Order;
    public interface IOrderQueryService
    {
        Task<OrderPreviewModel> PreviewOrderAsync(OrderPreview orderPreview);
    }
}
