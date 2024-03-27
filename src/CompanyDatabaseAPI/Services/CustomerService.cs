using AutoMapper;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Repositories;
using NuGet.Protocol.Core.Types;

namespace CompanyDatabaseAPI.Services;

public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
{
    public async Task<int> GetCustomerCountAsync()
    {
        return await customerRepository.GetCustomerCountAsync();
    }

    public async Task<IEnumerable<CustomerDTO>> GetCustomersAsync()
    {
        var customers = await customerRepository.GetCustomersAsync();
        return mapper.Map<IEnumerable<CustomerDTO>>(customers);
    }
}