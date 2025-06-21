using Api_Auth.Dtos;
using Api_Auth.Models;
using Api_Auth.Repositories.Interfaces;
using MongoDB.Driver;
using static Connection.Server;

namespace Api_Auth.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ILogger<LoginRepository> _logger;

        public LoginRepository(ILogger<LoginRepository> logger)
        {
            _logger = logger;
        }

        public async Task<LoginModel> GetUser(string email)
        {
            try
            {
                using(var conn = GetConectionDB_MongoDB())
                {
                    var database = conn.GetDatabase("ApiAuth");
                    var collection = database.GetCollection<RegisterModel>("Users");
                    var filter = Builders<RegisterModel>.Filter.Eq(u => u.Email, email);
                    var projection = Builders<RegisterModel>.Projection.Exclude("_id");
                    var result = await collection.Find(filter)
                                            .Project<RegisterModel>(projection)
                                            .FirstOrDefaultAsync();
                    return new LoginModel
                    {
                        Email = result.Email,
                        PassCrypt = result.PassCrypt
                    };
                }
            }
            catch (Exception e)
            {
                _logger.LogError("[GetUser] - Error retrieving user - {0}", e.Message);
                throw;
            }
        }

        public async Task<bool> RegisterUserAsync(RegisterModel registerModel)
        {
            try
            {
                using(var conn = GetConectionDB_MongoDB())
                {
                    var database = conn.GetDatabase("ApiAuth");
                    var collection = database.GetCollection<RegisterModel>("Users");
                    await collection.InsertOneAsync(registerModel);
                }
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[RegisterUserAsync] - Error registering user - {0}", e.Message);
                throw;
            }
        }

        public Task<bool> ValidateUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
