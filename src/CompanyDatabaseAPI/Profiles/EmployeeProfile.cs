using AutoMapper;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Models;

namespace CompanyDatabaseAPI.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDTO>();
    }
}