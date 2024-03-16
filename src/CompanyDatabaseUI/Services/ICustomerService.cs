using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyDatabaseUI.Services;

public interface ICustomerService
{
    Task<List<string>> GetCustomerListAsync();
}