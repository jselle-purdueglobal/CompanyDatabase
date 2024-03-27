using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;

namespace CompanyDatabaseUI.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomerListAsync();
    Task<int> GetCustomerCountAsync();
}