namespace StockExchange.Services.Models.User
{
    using Entity = DataContext.Entities;
    public static class Mappings
    {
        public static UserModel ToModel(this Entity.User user)
        {
            return new UserModel(user.Id, user.Name, user.InvestmentAccount!.Id, user.InvestmentAccount.CashBalance);
        }
    }
}
