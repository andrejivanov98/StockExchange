namespace VanLanschotKempen.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.Services.Abstractions.Services.Query;
    using StockExchange.Services.Models.Stock;

    [ApiController]
    [Route("api/stocks")]
    public class StockController : ControllerBase
    {
        private readonly IStockQueryService _stockQueryService;

        public StockController(IStockQueryService stockQueryService)
        {
            _stockQueryService = stockQueryService;
        }

        [HttpGet("{stockId}")]
        public async Task<ActionResult<StockModel>> GetStockDetailsAsync(Guid stockId)
        {
            var stock = await _stockQueryService.GetStockDetailsAsync(stockId);
            return Ok(stock);
        }

        [HttpGet("")]
        public async Task<ActionResult<List<StockModel>>> GetAllStocksAsync()
        {
            var stocks = await _stockQueryService.GetAllStocksAsync();
            return Ok(stocks);
        }
    }
}
