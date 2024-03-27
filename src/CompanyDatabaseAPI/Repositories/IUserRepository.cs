using CompanyDatabaseAPI.Models;

namespace CompanyDatabaseAPI.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
}