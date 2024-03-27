using System.Threading.Tasks;
using CompanyDatabaseUI.Models;

namespace CompanyDatabaseUI.Services;

public interface IAuthService
{
    Task<(bool, User)> AuthenticateAsync(string username, string password);
}