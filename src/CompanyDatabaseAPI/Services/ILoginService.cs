using CompanyDatabaseAPI.DTOs;

namespace CompanyDatabaseAPI.Services;

public interface ILoginService
{
    Task<LoginDTO> GetByUsername(string username);
}