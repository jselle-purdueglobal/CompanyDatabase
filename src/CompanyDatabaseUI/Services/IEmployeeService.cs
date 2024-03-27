using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;

namespace CompanyDatabaseUI.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetEmployeeListAsync();
    Task<int> GetEmployeeCountAsync();
}