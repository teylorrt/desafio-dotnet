
namespace ByCodersChallengeDotNet.Infrastructure
{
    public static class Config
    {
        public static string? GetDefaultConnectionString(IConfiguration configuration)
        {
            string? connectionString = Environment.GetEnvironmentVariable("DefaultConnectionString");

            connectionString ??= configuration.GetConnectionString("DefaultConnectionString");

            return connectionString;
        }
    }
}
