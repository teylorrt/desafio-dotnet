using ByCodersChallengeDotNet.Infrastructure.DbContext;
using ByCodersChallengeDotNet.IntegrationTests.DbContext;
using Microsoft.Extensions.Configuration;

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
    }
}
