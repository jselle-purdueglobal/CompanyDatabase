using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Models;

namespace CompanyDatabaseAPI.Repositories;

public interface ICustomerRepository
{
    Task<int> GetCustomerCountAsync();
    Task<IEnumerable<Customer>> GetCustomersAsync();
}