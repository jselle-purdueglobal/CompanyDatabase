using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;

namespace CompanyDatabaseUI.Services;

public class AuthService(HttpClient httpClient) : IAuthService
{
    private const string BaseUrl = "http://localhost:5173/api/users/login";

    public async Task<(bool, User)> AuthenticateAsync(string username, string password)
    {
        // Attempt to retrieve user
        var response = await httpClient.GetAsync($"{BaseUrl}/{username}");
        if (!response.IsSuccessStatusCode) return (false, new User());
        
        // Parse user object from response
        var user = await response.Content.ReadFromJsonAsync<User>();
        if (user is null) return (false, new User());
        
        // Verify password
        var passwordVerified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        return passwordVerified ? (true, user) : (false, new User());
    }
}