using CompanyDatabaseAPI.DTOs;

namespace CompanyDatabaseAPI.Services;

public interface ICustomerService
{
    Task<int> GetCustomerCountAsync();
    Task<IEnumerable<CustomerListDto>> GetCustomerListAsync();
}