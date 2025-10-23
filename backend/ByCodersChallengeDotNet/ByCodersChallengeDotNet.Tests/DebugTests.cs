using ByCodersChallengeDotNet.Application.Services;
using ByCodersChallengeDotNet.Infrastructure.Repositories;

namespace ByCodersChallengeDotNet.Tests
{
    public class DebugTests : TestBase
    {
        [Fact]
        public void DebugTest()
        {
            using var input = System.IO.File.OpenRead("CNAB.txt");

            var operationService = new OperationService(new OperationRepository(DbContext));
            var imported = operationService.ImportOperations(input);

            Assert.True(imported);

            var list = operationService.ListOperationsByStore();

            Assert.Equal(21, list.SelectMany(d => d.Operations).Count());
        }

        [Fact]
        public void TestList()
        {
            var operationService = new OperationService(new OperationRepository(DbContext));

            var list = operationService.ListOperationsByStore();

            Assert.Equal(21, list.SelectMany(d => d.Operations).Count());
        }
    }
}
