using Microsoft.AspNetCore.Mvc;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Services;

namespace CompanyDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService service) : ControllerBase
    {
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetOrderCount()
        {
            var count = await service.GetOrderCountAsync();
            return Ok(count);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = await service.GetOrdersAsync();
            return Ok(orders);
        }
    }
}