namespace StockExchange.Services.Services.Query
{
    using StockExchange.DataContext.Entities;
    using StockExchange.Services.Abstractions.Repositories;
    using StockExchange.Services.Abstractions.Services.Query;
    using StockExchange.Services.Models.Stock;
    using StockExchange.Services.Models.User;
    public class StockQueryService : IStockQueryService
    {
        private readonly IRepository<Stock> _stockRepository;

        public StockQueryService(IRepository<Stock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<List<StockModel>> GetAllStocksAsync()
        {
            var stocks = await _stockRepository.GetAllAsync();

            if (stocks == null)
            {
                throw new InvalidOperationException("There are no stocks.");
            }

            return stocks.Select(s => s.ToModel()).ToList();
        }

        public async Task<StockModel> GetStockDetailsAsync(Guid stockId)
        {
            var stock = await _stockRepository.GetByIdAsync(stockId);

            if (stock == null)
            {
                throw new InvalidOperationException("Stock not found.");
            }

            return stock.ToModel();
        }
    }
}
