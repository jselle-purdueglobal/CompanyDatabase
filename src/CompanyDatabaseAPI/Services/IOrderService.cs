using CompanyDatabaseAPI.DTOs;

namespace CompanyDatabaseAPI.Services;

public interface IOrderService
{
    Task<int> GetOrderCountAsync();
    Task<IEnumerable<OrderDTO>> GetOrdersAsync();
}