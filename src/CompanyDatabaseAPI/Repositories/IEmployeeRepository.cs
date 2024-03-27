using CompanyDatabaseAPI.Models;

namespace CompanyDatabaseAPI.Repositories;

public interface IEmployeeRepository
{
    Task<int> GetEmployeeCountAsync();
    Task<IEnumerable<Employee>> GetEmployeesAsync();
}