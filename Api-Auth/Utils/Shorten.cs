namespace Utils
{
    public class Shorten
    {
        public static string? Env(string name)
        {
            var resp = Environment.GetEnvironmentVariable(name);
            return resp;
        }
    }
}
