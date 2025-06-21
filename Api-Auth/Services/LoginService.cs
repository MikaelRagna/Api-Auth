using Api_Auth.Dtos;
using Api_Auth.Models;
using static Utils.Helper;
using Api_Auth.Repositories.Interfaces;
using Api_Auth.Services.Interfaces;
using AutoMapper;

namespace Api_Auth.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogger<LoginService> _logger;
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginService(ILogger<LoginService> logger, ILoginRepository loginRepository, IMapper mapper)
        {
            _logger = logger;
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<TokenDto> LoginUserAsync(LoginDto loginDto)
        {
            try
            {
                var userExists = await _loginRepository.GetUser(loginDto.Email);

                if (userExists == null)
                {
                    _logger.LogWarning("[LoginUserAsync] - User not found with email: {0}", loginDto.Email);
                    throw new Exception("User not found");
                }

                var isValidUser = BCrypt.Net.BCrypt.Verify(loginDto.Password, userExists.PassCrypt);

                if (!isValidUser)
                {
                    _logger.LogWarning("[LoginUserAsync] - Invalid password for user: {0}", loginDto.Email);
                    throw new Exception("Invalid password");
                }

                return GenerateToken(userExists.Email);
            }
            catch (Exception e)
            {
                _logger.LogError("[LoginUserAsync] - Message: {0}", e.Message);
                throw;
            }
        }

        public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
        {
            try
            {
                var userExists = await _loginRepository.GetUser(registerDto.Email);

                if (userExists != null)
                {
                    _logger.LogWarning("[RegisterUserAsync] - User already exists with email: {0}", registerDto.Email);
                    throw new Exception("User already exists");
                }

                var user = _mapper.Map<RegisterModel>(registerDto);

                await _loginRepository.RegisterUserAsync(user);

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[RegisterUserAsync] - Message: {0}", e.Message);
                throw;
            }
        }
    }
}
