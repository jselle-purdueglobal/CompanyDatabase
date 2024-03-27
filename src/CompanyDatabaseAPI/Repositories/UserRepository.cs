using AutoMapper;
using CompanyDatabaseAPI.Data;
using CompanyDatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyDatabaseAPI.Repositories;

public class UserRepository(NorthwindContext context) : IUserRepository
{
    public async Task<List<User>> GetUsersAsync()
    {
        return await context.Users.Include(u => u.Role).ToListAsync();
    }
}