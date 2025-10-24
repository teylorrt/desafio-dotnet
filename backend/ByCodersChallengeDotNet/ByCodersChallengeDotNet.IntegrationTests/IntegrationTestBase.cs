using ByCodersChallengeDotNet.Infrastructure.DbContext;
using ByCodersChallengeDotNet.IntegrationTests.DbContext;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ByCodersChallengeDotNet.IntegrationTests
{
    public class IntegrationTestBase : IDisposable
    {
        private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

        protected readonly IDbContext DbContext;

        public IntegrationTestBase()
        {
            DbContext = new DbContextTest(_configuration);

            DbContext.Connection.Open();

            DbContext.BeginTransaction();
        }

        public void Dispose()
        {
            DbContext.RollbackTransaction();
            DbContext.Connection.Close();
        }

        public static string BuildRandomString(string saltCharacters, int length = 10)
        {
            var salt = new StringBuilder();
            for (var i = 1; i <= length; i++)
            {
                var index = BuildRandomNumber(0, saltCharacters.Length - 1);
                salt.Append(saltCharacters.Substring(index, 1));
            }
            return salt.ToString();
        }

        public static int BuildRandomNumber(int min = 1, int max = 100)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        public static string BuildRandomStringWithNumbers(int length = 10)
        {
            // ReSharper disable once StringLiteralTypo
            return BuildRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", length);
        }
    }
}
