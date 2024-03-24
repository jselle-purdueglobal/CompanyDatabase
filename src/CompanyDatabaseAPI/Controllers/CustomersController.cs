using System;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Services;

namespace CompanyDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService service) : ControllerBase
    {
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCustomerCount()
        {
            var count = await service.GetCustomerCountAsync();
            return Ok(count);
        }

        [HttpGet("names")]
        public async Task<ActionResult<IEnumerable<CustomerNameDto>>> GetCustomers()
        {
            var customers = await service.GetCustomersAsync();
            return Ok(customers);
        }
    }
}
