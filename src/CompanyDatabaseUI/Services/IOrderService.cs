using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;

namespace CompanyDatabaseUI.Services;

public interface IOrderService
{
    Task<List<Order>> GetOrderListAsync();
    Task<int> GetOrderCountAsync();
}