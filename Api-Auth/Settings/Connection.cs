using MongoDB.Driver;
using static Settings.Variants;
namespace Connection
{
    public class Server
    {
        public static MongoClient GetConectionDB_MongoDB()
        {
            var connectionString = ConectionStringDB_MongoDB();
            return new MongoClient(connectionString);
        }

        public static string ConectionStringDB_MongoDB()
        {
            return $"mongodb://{DATABASE_USER}:{DATABASE_PASS}@{DATABASE_HOST}:{DATABASE_PORT}";
        }
    }
}
