using CompanyDatabaseAPI.Data;
using CompanyDatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyDatabaseAPI.Repositories;

public class OrderRepository(NorthwindContext context) : IOrderRepository
{
    public async Task<int> GetOrderCountAsync()
    {
        return await context.Orders.CountAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await context.Orders.ToListAsync();
    }
}