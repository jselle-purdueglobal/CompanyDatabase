using System.Text.Json.Serialization;

namespace CompanyDatabaseUI.Models;

public class Order
{
    [JsonPropertyName("OrderID")]
    public int OrderId { get; set; }
    [JsonPropertyName("EmployeeID")]
    public int EmployeeId { get; set; }
    [JsonPropertyName("CustomerID")]
    public int CustomerId { get; set; }
}