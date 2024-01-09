using Microsoft.EntityFrameworkCore;
using StockExchange.DataContext;
using StockExchange.DataContext.Entities;
using StockExchange.Services.Abstractions.Repositories;
using StockExchange.Services.Abstractions.Services.Command;
using StockExchange.Services.Abstractions.Services.Query;
using StockExchange.Services.Repositories;
using StockExchange.Services.Services.Command;
using StockExchange.Services.Services.Query;
using VanLanschotKempen.API.Utils;

var builder = WebApplication.CreateBuilder(args);

// In-memory Database registered
builder.Services.AddDbContext<StockExchangeContext>(options =>
    options.UseInMemoryDatabase("StockExchangeDB"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Stock Exchange API",
        Version = "v1"
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Repositories
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Stock>, Repository<Stock>>();
builder.Services.AddScoped<IRepository<Portfolio>, Repository<Portfolio>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<IRepository<InvestmentAccount>, Repository<InvestmentAccount>>();

// Services
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IStockQueryService, StockQueryService>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<StockExchangeContext>();
dbContext.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock Exchange API V1");
        c.RoutePrefix = "swagger";
    });
}

//Custom middleware for handling global exceptions
app.UseMiddleware<CustomExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
