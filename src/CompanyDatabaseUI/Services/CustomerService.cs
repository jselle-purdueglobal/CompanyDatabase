using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;

namespace CompanyDatabaseUI.Services;

public class CustomerService(HttpClient httpClient) : ICustomerService
{
    private const string BaseUrl = "http://localhost:5173/api/customers";
    
    public async Task<List<Customer>> GetCustomerListAsync()
    {
        var response = await httpClient.GetAsync(BaseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var customers = JsonSerializer.Deserialize<List<Customer>>(content);
        return customers ?? new List<Customer>();
    }
    
    public async Task<int> GetCustomerCountAsync()
    {
        var response = await httpClient.GetAsync($"{BaseUrl}/count");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<int>(content);
    }
}