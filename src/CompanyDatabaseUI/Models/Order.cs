using System.Text.Json.Serialization;

namespace CompanyDatabaseUI.Models;

public class Order
{
    [JsonPropertyName("orderID")]
    public int OrderId { get; set; }
    [JsonPropertyName("employeeID")]
    public int EmployeeId { get; set; }
    [JsonPropertyName("customerID")]
    public string CustomerId { get; set; }
}