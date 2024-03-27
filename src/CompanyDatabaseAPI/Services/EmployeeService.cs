using AutoMapper;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Repositories;

namespace CompanyDatabaseAPI.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) : IEmployeeService
{
    public async Task<int> GetEmployeeCountAsync()
    {
        return await employeeRepository.GetEmployeeCountAsync();
    }

    public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync()
    {
        var employee = await employeeRepository.GetEmployeesAsync();
        return mapper.Map<IEnumerable<EmployeeDTO>>(employee);
    }
}