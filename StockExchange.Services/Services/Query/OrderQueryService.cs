namespace StockExchange.Services.Services.Query
{
    using StockExchange.DataContext.Entities;
    using StockExchange.Services.Abstractions.Repositories;
    using StockExchange.Services.Abstractions.Services.Query;
    using StockExchange.Services.Models.Order;
    public class OrderQueryService : IOrderQueryService
    {
        private readonly IRepository<InvestmentAccount> _accountRepository;
        private readonly IRepository<Stock> _stockRepository;

        public OrderQueryService(
            IRepository<InvestmentAccount> accountRepository,
            IRepository<Stock> stockRepository)
        {
            _accountRepository = accountRepository;
            _stockRepository = stockRepository;
        }

        public async Task<OrderPreviewModel> PreviewOrderAsync(OrderPreview orderPreview)
        {
            var stock = await _stockRepository.GetByIdAsync(orderPreview.StockId);

            if (stock == null)
            {
                throw new InvalidOperationException("Stock not found.");
            }

            var totalCost = orderPreview.NumberOfShares * stock.CurrentPrice;
            var isOrderValid = await ValidateOrderAsync(orderPreview.AccountId, totalCost);

            return new OrderPreviewModel(orderPreview.StockId, stock.Name, orderPreview.NumberOfShares, totalCost, isOrderValid);
        }

        private async Task<bool> ValidateOrderAsync(Guid accountId, decimal totalCost)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);

            if (account == null)
            {
                throw new InvalidOperationException("Account not found.");
            }

            return account.IsEnoughCashBalance(account.CashBalance, totalCost);
        }
    }
}
