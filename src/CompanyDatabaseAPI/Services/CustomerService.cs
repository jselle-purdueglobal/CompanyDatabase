using AutoMapper;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Repositories;
using NuGet.Protocol.Core.Types;

namespace CompanyDatabaseAPI.Services;

public class CustomerService(ICustomerRepository repository, IMapper mapper) : ICustomerService
{
    public async Task<int> GetCustomerCountAsync()
    {
        return await repository.GetCustomerCountAsync();
    }

    public async Task<IEnumerable<CustomerNameDto>> GetCustomersAsync()
    {
        var customers = await repository.GetCustomersAsync();
        return mapper.Map<IEnumerable<CustomerNameDto>>(customers);
    }
}