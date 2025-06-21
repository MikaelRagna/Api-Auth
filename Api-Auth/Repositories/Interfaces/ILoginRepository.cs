using Api_Auth.Models;

namespace Api_Auth.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<bool> ValidateUserAsync(string email, string password);
        Task<bool> RegisterUserAsync(RegisterModel registerModel);
        Task<LoginModel> GetUser (string email);
    }
}
