namespace CompanyDatabaseAPI.DTOs;

public class CustomerDto
{
    public string Id { get; set; } = null!;
    
    public string CompanyName { get; set; } = null!;
    
    public string? ContactName { get; set; }
    
    public string? ContactTitle { get; set; }
    
    public string? Phone { get; set; }
    
    public string? City { get; set; }
    
    public string? Country { get; set; }
}