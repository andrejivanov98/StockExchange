namespace StockExchange.Services.Models.User
{
    public record UserModel(
    Guid Id,
    string Name,
    Guid AccountId,
    decimal CashBalance);
}
