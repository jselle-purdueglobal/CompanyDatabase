using CompanyDatabaseAPI.Models;

namespace CompanyDatabaseAPI.Repositories;

public interface IOrderRepository
{
    Task<int> GetOrderCountAsync();
    Task<IEnumerable<Order>> GetOrdersAsync();
}