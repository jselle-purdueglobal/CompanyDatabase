using CompanyDatabaseAPI.Models;

namespace CompanyDatabaseAPI.DTOs;

public class UserDTO
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public RoleDTO Role { get; set; } = null!;
}