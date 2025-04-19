namespace ECommerceAPI.Application.Services.Auth;

public interface IAuthService
{
    Task<string> RegisterAsync(string username, string email, string password);
    Task<string> LoginAsync(string email, string password);
    Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
} 