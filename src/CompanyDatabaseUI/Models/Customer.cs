using System.Text.Json.Serialization;

namespace CompanyDatabaseUI.Models;

public class Customer
{
    [JsonPropertyName("companyName")]
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
}