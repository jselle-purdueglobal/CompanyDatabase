using AutoMapper;
using AutoMapper.QueryableExtensions;
using CompanyDatabaseAPI.Data;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyDatabaseAPI.Repositories;

public class CustomerRepository(NorthwindContext context, IMapper mapper) : ICustomerRepository
{
    public async Task<int> GetCustomerCountAsync()
    {
        return await context.Customers.CountAsync();
    }
    
    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await context.Customers.ToListAsync();
    }
}