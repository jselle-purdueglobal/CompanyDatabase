using Microsoft.AspNetCore.Mvc;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Services;

namespace CompanyDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService service) : ControllerBase
    {
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetEmployeeCount()
        {
            var count = await service.GetEmployeeCountAsync();
            return Ok(count);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await service.GetEmployeesAsync();
            return Ok(employees);
        }
    }
}