using AutoMapper;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Models;

namespace CompanyDatabaseAPI.Profiles;

public class RolePermissionProfile : Profile
{
    public RolePermissionProfile()
    {
        CreateMap<RolePermission, RolePermissionDTO>();
    }
}