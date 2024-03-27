using CompanyDatabaseAPI.Data;
using CompanyDatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyDatabaseAPI.Repositories;

public class EmployeeRepository(NorthwindContext context) : IEmployeeRepository
{
    public async Task<int> GetEmployeeCountAsync()
    {
        return await context.Employees.CountAsync();
    }
    
    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await context.Employees.ToListAsync();
    }
}