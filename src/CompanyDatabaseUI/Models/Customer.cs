using System.Text.Json.Serialization;

namespace CompanyDatabaseUI.Models;

public class Customer
{
    [JsonPropertyName("companyName")]
    public string Name { get; set; } = null!;
}