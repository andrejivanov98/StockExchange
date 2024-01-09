namespace StockExchange.Services.Models.Order
{
    using Entity = DataContext.Entities;
    public static class Mappings
    {
        public static OrderModel ToModel(this Entity.Order order)
        {
            var stockName = order.Stock?.Name ?? "Unknown";
            var cashBalance = order.InvestmentAccount?.CashBalance ?? 0;

            return new OrderModel(order.Id, order.InvestmentAccountId, order.StockId, stockName, order.NumberOfShares, order.TotalCost, cashBalance);
        }
    }
}
