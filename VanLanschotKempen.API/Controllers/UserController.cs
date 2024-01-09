namespace VanLanschotKempen.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.Services.Abstractions.Services.Query;
    using StockExchange.Services.Models.User;

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userQueryService;

        public UserController(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserModel>> GetUserDetailsAsync(Guid userId)
        {
            var user = await _userQueryService.GetUserDetailsAsync(userId);
            return Ok(user);
        }
    }
}
