using CompanyDatabaseAPI.DTOs;

namespace CompanyDatabaseAPI.Services;

public interface IEmployeeService
{
    Task<int> GetEmployeeCountAsync();
    Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync();
}