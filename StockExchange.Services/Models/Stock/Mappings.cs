namespace StockExchange.Services.Models.Stock
{
    using Entity = DataContext.Entities;
    public static class Mappings
    {
        public static StockModel ToModel(this Entity.Stock stock)
        {
            return new StockModel(stock.Id, stock.Name, stock.CurrentPrice);
        }
    }
}
