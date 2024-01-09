namespace StockExchange.Services.Abstractions.Services.Command
{
    using StockExchange.Services.Models.Order;
    public interface IOrderCommandService
    {
        Task<OrderModel> CreateOrderAsync(OrderCreate createModel);
    }
}
