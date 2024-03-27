using AutoMapper;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Models;

namespace CompanyDatabaseAPI.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleDTO>();
    }
}