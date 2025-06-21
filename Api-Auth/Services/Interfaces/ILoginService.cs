using Api_Auth.Dtos;
using Api_Auth.Models;

namespace Api_Auth.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<bool> RegisterUserAsync(RegisterDto registerDto);
        public Task<TokenDto> LoginUserAsync(LoginDto loginDto);
    }
}
