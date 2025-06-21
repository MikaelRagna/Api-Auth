using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Api_Auth.Models
{
    public class LoginModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public string PassCrypt { get; set; }
    }

    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassCrypt { get; set; }
        public DateTime DateRegister { get; set; }
    }
}