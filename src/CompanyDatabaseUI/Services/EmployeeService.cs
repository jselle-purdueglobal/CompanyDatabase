using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;

namespace CompanyDatabaseUI.Services;

public class EmployeeService(HttpClient httpClient) : IEmployeeService
{
    private const string BaseUrl = "http://localhost:5173/api/employees";
    
    public async Task<List<Employee>> GetEmployeeListAsync()
    {
        var response = await httpClient.GetAsync(BaseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var employees = JsonSerializer.Deserialize<List<Employee>>(content);
        return employees ?? new List<Employee>();
    }
    
    public async Task<int> GetEmployeeCountAsync()
    {
        var response = await httpClient.GetAsync($"{BaseUrl}/count");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var count = JsonSerializer.Deserialize<int>(content);
        return count;
    }
}