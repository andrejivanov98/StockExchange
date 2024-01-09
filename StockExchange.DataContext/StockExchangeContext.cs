#nullable disable

namespace StockExchange.DataContext
{
    using Microsoft.EntityFrameworkCore;
    using StockExchange.DataContext.Entities;
    public class StockExchangeContext : DbContext
    {
        public StockExchangeContext(DbContextOptions<StockExchangeContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<InvestmentAccount> InvestmentAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User to InvestmentAccount as one-to-one
            modelBuilder.Entity<User>()
                .HasOne(u => u.InvestmentAccount)
                .WithOne(ia => ia.User)
                .HasForeignKey<InvestmentAccount>(ia => ia.UserId);

            // InvestmentAccount to Portfolio as one-to-many
            modelBuilder.Entity<InvestmentAccount>()
                .HasMany(ia => ia.Portfolios)
                .WithOne(p => p.InvestmentAccount);

            // Portfolio to Stock as many-to-one
            modelBuilder.Entity<Portfolio>()
                .HasOne(p => p.Stock)
                .WithMany(s => s.Portfolios);

            // Order relationships
            modelBuilder.Entity<Order>()
                .HasOne(o => o.InvestmentAccount)
                .WithMany()
                .HasForeignKey(o => o.InvestmentAccountId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Stock)
                .WithMany()
                .HasForeignKey(o => o.StockId);

            // Seed initial data

            // Logged user Id
            var userId = Guid.Parse("40cf0867-c2cc-4aab-9ef7-f40590791dee");

            var accountId = Guid.NewGuid();
            var stockId = Guid.NewGuid();
            var portfolioId = Guid.NewGuid();

            var initialUser = new User("WC Funds", userId);
            var initialInvestmentAccount = new InvestmentAccount(userId, 2000, accountId);
            var initialStock = new Stock("Apple", 150, stockId);
            var initialPortfolio = new Portfolio(accountId, stockId, 0, portfolioId);

            modelBuilder.Entity<User>().HasData(initialUser);
            modelBuilder.Entity<InvestmentAccount>().HasData(initialInvestmentAccount);
            modelBuilder.Entity<Stock>().HasData(initialStock);
            modelBuilder.Entity<Portfolio>().HasData(initialPortfolio);
        }
    }
}
