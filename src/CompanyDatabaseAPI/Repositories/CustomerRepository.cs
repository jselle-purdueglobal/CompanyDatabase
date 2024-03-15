using AutoMapper;
using AutoMapper.QueryableExtensions;
using CompanyDatabaseAPI.Data;
using CompanyDatabaseAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CompanyDatabaseAPI.Repositories;

public class CustomerRepository(NorthwindContext context, IMapper mapper) : ICustomerRepository
{
    public async Task<int> GetCustomerCount()
    {
        return await context.Customers.CountAsync();
    }
    
    public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
    {
        return await context.Customers
            .ProjectTo<CustomerDto>(mapper.ConfigurationProvider).ToListAsync();
    }
}