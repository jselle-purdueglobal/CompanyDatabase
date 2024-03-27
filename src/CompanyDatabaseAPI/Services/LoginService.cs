using AutoMapper;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Repositories;

namespace CompanyDatabaseAPI.Services;

public class LoginService(IUserRepository userRepository, IMapper mapper) : ILoginService
{
    public async Task<LoginDTO?> GetByUsername(string username)
    {
        var users = await userRepository.GetUsersAsync();
        var user = users.FirstOrDefault(u => u.Username == username);
        return user != null ? mapper.Map<LoginDTO>(user) : null;
    }
}