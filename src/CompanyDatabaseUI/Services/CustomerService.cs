using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompanyDatabaseUI.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "http://localhost.com/api/customers";

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<string>> GetCustomerListAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var customerNames = JsonSerializer.Deserialize<List<string>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return customerNames ?? new List<string>();
        }
        catch (HttpRequestException e)
        {
            // Log and handle exceptions
            Console.WriteLine($"An error occurred: {e.Message}");
            return new List<string>();
        }
    }
}