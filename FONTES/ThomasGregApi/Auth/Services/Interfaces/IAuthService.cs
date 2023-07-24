using Microsoft.AspNetCore.Identity;

namespace Auth.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string nome, string senha);
        Task<IdentityResult> RegisterUserAsync(string nome, string senha);
    }
}
