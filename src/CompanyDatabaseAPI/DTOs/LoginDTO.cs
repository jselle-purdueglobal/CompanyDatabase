namespace CompanyDatabaseAPI.DTOs;

public class LoginDTO
{
    public string Username { get; init; } = null!;
    public string PasswordHash { get; init; } = null!;
    public string Role { get; init; } = null!;
}