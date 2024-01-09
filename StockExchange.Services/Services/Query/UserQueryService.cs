namespace StockExchange.Services.Services.Query
{
    using StockExchange.DataContext.Entities;
    using StockExchange.Services.Abstractions.Repositories;
    using StockExchange.Services.Abstractions.Services.Query;
    using StockExchange.Services.Models.User;

    public class UserQueryService : IUserQueryService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<InvestmentAccount> _accountRepository;

        public UserQueryService(IRepository<User> userRepository, IRepository<InvestmentAccount> accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public async Task<UserModel> GetUserDetailsAsync(Guid userId)
        {
            var accounts = await _accountRepository.GetAllAsync();
            var account = accounts.SingleOrDefault(x => x.UserId == userId);
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            if (account != null)
            {
                user.AddInvestmentAccount(account);
            }

            return user.ToModel();
        }
    }
}
