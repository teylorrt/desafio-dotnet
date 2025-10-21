using ByCodersChallenge.Application.Service;
using ByCodersChallenge.Infrastructure.Repository;

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
        }
    }
}
