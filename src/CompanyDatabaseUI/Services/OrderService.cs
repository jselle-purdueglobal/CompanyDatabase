using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;

namespace CompanyDatabaseUI.Services;

public class OrderService(HttpClient httpClient) : IOrderService
{
    private const string BaseUrl = "http://localhost:5173/api/orders";
    
    public async Task<List<Order>> GetOrderListAsync()
    {
        var response = await httpClient.GetAsync(BaseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var orders = JsonSerializer.Deserialize<List<Order>>(content);
        return orders ?? new List<Order>();
    }
    
    public async Task<int> GetOrderCountAsync()
    {
        var response = await httpClient.GetAsync($"{BaseUrl}/count");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var count = JsonSerializer.Deserialize<int>(content);
        return count;
    }
}