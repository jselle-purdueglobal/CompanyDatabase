using Microsoft.AspNetCore.Mvc;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Repositories;

namespace CompanyDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCustomerCount()
        {
            var count = await _repository.GetCustomerCount();
            return Ok(count);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _repository.GetCustomersAsync();
            return Ok(customers);
        }
    }
}
