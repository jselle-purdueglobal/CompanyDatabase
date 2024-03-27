using AutoMapper;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Models;

namespace CompanyDatabaseAPI.Profiles;

public class LoginProfile : Profile
{
    public LoginProfile()
    {
        CreateMap<User, LoginDTO>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleName));
    }
}