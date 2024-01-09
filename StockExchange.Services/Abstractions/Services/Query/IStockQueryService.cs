namespace StockExchange.Services.Abstractions.Services.Query
{
    using StockExchange.Services.Models.Stock;
    public interface IStockQueryService
    {
        Task<List<StockModel>> GetAllStocksAsync();
        Task<StockModel> GetStockDetailsAsync(Guid stockId);
    }
}
