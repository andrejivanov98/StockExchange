namespace VanLanschotKempen.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.Services.Abstractions.Services.Command;
    using StockExchange.Services.Abstractions.Services.Query;
    using StockExchange.Services.Models.Order;

    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderQueryService _orderQueryService;
        private readonly IOrderCommandService _orderCommandService;

        public OrderController(IOrderQueryService orderQueryService, IOrderCommandService orderCommandService)
        {
            _orderQueryService = orderQueryService;
            _orderCommandService = orderCommandService;
        }

        [HttpPost("preview")]
        public async Task<ActionResult<OrderPreviewModel>> PreviewOrderAsync(OrderPreview orderPreview)
        {
            var preview = await _orderQueryService.PreviewOrderAsync(orderPreview);
            return Ok(preview);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OrderModel>> CreateOrderAsync(OrderCreate createModel)
        {
            var order = await _orderCommandService.CreateOrderAsync(createModel);

            return Created($"api/orders/{order.Id}", order);
        }
    }
}