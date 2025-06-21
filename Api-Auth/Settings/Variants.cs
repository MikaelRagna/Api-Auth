using static Utils.Shorten;
namespace Settings
{
    public class Variants
    {
        public static readonly string APPLICATION_NAME = Env("APPLICATION_NAME") ?? "API Auth";

        public static readonly string DATABASE_HOST = Env("DATABASE_HOST") ?? "localhost";
        public static readonly string DATABASE_USER = Env("DATABASE_USER") ?? "root_mongodb";
        public static readonly string DATABASE_PASS = Env("DATABASE_PASS") ?? "Mongo1*db";
        public static readonly string DATABASE_PORT = Env("DATABASE_PORT") ?? "27017";

        public static readonly string SECRET_KEY = Env("SECRET_KEY") ?? "Teste@123";

    }
}
