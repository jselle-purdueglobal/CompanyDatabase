namespace CompanyDatabaseAPI.DTOs;

public class RolePermissionDTO
{
    public int RolePermissionId { get; set; }
    public string TableName { get; set; } = null!;
    public string PermissionType { get; set; } = null!;
}