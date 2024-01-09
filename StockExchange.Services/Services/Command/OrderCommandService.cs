namespace StockExchange.Services.Services.Command
{
    using StockExchange.DataContext.Entities;
    using StockExchange.Services.Abstractions.Repositories;
    using StockExchange.Services.Abstractions.Services.Command;
    using StockExchange.Services.Models.Order;
    public class OrderCommandService : IOrderCommandService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<InvestmentAccount> _accountRepository;
        private readonly IRepository<Stock> _stockRepository;

        public OrderCommandService(IRepository<Order> orderRepository, IRepository<InvestmentAccount> accountRepository, IRepository<Stock> stockRepository)
        {
            _orderRepository = orderRepository;
            _accountRepository = accountRepository;
            _stockRepository = stockRepository;
        }

        public async Task<OrderModel> CreateOrderAsync(OrderCreate createModel)
        {
            var account = await _accountRepository.GetByIdAsync(createModel.AccountId);
            var stock = await _stockRepository.GetByIdAsync(createModel.StockId);

            if (createModel.NumberOfShares < 0)
            {
                throw new InvalidOperationException("Number of shares cannot be negative.");
            }

            if (account == null || stock == null)
            {
                throw new InvalidOperationException("Account or Stock not found.");
            }

            var totalCost = createModel.NumberOfShares * stock.CurrentPrice;
            var isCashBalanceValid = account.IsEnoughCashBalance(account.CashBalance, totalCost);

            if (!isCashBalanceValid)
            {
                throw new InvalidOperationException("Insufficient funds to place the order.");
            }

            var order = new Order(account.Id, stock.Id, createModel.NumberOfShares, totalCost);

            await _orderRepository.InsertAsync(order);

            account.UpdateCashBalance(totalCost);

            await _accountRepository.UpdateAsync(account);

            return order.ToModel();
        }
    }
}
