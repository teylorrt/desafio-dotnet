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

            var list = operationService.ListOperationsByStore();

            Assert.Equal(21, list.Count());
        }

        [Fact]
        public void TestList()
        {
            DateTimeOffset localTime, otherTime, universalTime;

            // Define local time in local time zone
            localTime = new DateTimeOffset(new DateTime(2007, 6, 15, 12, 0, 0));
            Console.WriteLine($"Local time: {localTime}");

            var operationService = new OperationService(new OperationRepository(new DapperDbContext(configuration)));

            var list = operationService.ListOperationsByStore();

            Assert.NotNull(list);
        }
    }
}
