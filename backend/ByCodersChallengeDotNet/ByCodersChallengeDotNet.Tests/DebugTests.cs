using ByCodersChallengeDotNet.Application.Services;
using ByCodersChallengeDotNet.Infrastructure.DbContext;
using ByCodersChallengeDotNet.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace ByCodersChallengeDotNet.Tests
{
    public class DebugTests
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        [Fact]
        public void DebugTest()
        {
            using var input = System.IO.File.OpenRead("CNAB.txt");

            var operationService = new OperationService(new OperationRepository(new DapperDbContext(configuration)));
            var imported = operationService.ImportOperations(input);

            Assert.True(imported);

            var list = operationService.ListOperations();

            Assert.Equal(21, list.Count());
        }
    }
}
