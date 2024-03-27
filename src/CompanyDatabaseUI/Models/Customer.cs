using System.Text.Json.Serialization;

namespace CompanyDatabaseUI.Models;

public class Customer
{
    [JsonPropertyName("companyName")]
    public string Name { get; set; } = null!;
    [JsonPropertyName("city")]
    public string City { get; set; } = null!;
    [JsonPropertyName("country")]
    public string Country { get; set; } = null!;
}