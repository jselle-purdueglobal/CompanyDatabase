using AutoMapper;
using CompanyDatabaseAPI.Data;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyDatabaseAPI.Services;

public class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
{
    public async Task<int> GetOrderCountAsync()
    {
        return await orderRepository.GetOrderCountAsync();
    }

    public async Task<IEnumerable<OrderDTO>> GetOrdersAsync()
    {
        var order = await orderRepository.GetOrdersAsync();
        return mapper.Map<IEnumerable<OrderDTO>>(order);
    }
}