using System.Text.Json.Serialization;

namespace CompanyDatabaseUI.Models;

public class Employee
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = null!;
    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = null!;
    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;
}