using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;

namespace CompanyDatabaseUI.Services;

public interface ICustomerApiService
{
    Task<List<Customer>> GetCustomerListAsync();
    Task<int> GetCustomerCountAsync();
}