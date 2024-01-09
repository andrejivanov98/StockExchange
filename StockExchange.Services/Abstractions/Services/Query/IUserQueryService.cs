using StockExchange.Services.Models.User;

namespace StockExchange.Services.Abstractions.Services.Query
{
    public interface IUserQueryService
    {
        Task<UserModel> GetUserDetailsAsync(Guid userId);
    }
}
