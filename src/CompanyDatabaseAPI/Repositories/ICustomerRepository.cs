using CompanyDatabaseAPI.DTOs;

namespace CompanyDatabaseAPI.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerDto>> GetCustomersAsync();
    Task<int> GetCustomerCount();
}