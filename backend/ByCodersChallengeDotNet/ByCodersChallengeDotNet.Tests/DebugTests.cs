using ByCodersChallengeDotNet.Application.Services;
using ByCodersChallengeDotNet.Infrastructure.Repositories;

namespace ByCodersChallengeDotNet.Tests
{
    public class DebugTests
    {
        [Fact]
        public void DebugTest()
        {
            var input = System.IO.File.ReadAllText("CNAB.txt");

            var operationService = new OperationService(new OperationRepository());
            var imported = operationService.ImportOperations(input);

            Assert.True(imported);

            var list = operationService.ListOperations();

            Assert.Equal(21, list.Count());
        }
    }
}
