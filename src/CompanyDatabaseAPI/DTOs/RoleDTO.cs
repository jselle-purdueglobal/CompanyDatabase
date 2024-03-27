namespace CompanyDatabaseAPI.DTOs;

public class RoleDTO
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public ICollection<RolePermissionDTO> RolePermissions { get; set; } = null!;
}