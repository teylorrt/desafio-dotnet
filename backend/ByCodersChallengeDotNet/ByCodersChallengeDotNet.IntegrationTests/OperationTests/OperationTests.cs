using ByCodersChallengeDotNet.Application.Services;
using ByCodersChallengeDotNet.Core.Models;
using ByCodersChallengeDotNet.Infrastructure.Repositories;

namespace ByCodersChallengeDotNet.IntegrationTests.OperationTests
{
    public class OperationTests : IntegrationTestBase
    {
        private IEnumerable<OperationGroupModel> ImportOperations()
        {
            using var input = System.IO.File.OpenRead("CNAB.txt");

            var operationService = new OperationService(new OperationRepository(DbContext));
            var imported = operationService.ImportOperations(input);

            Assert.True(imported);

            var list = operationService.ListOperationsByStore();

            Assert.Equal(21, list.SelectMany(d => d.Operations).Count());

            return list;
        }

        [Fact, Trait("Category", "Integration")]
        public void TestImportOperations()
        {
            _ = ImportOperations();
        }

        [Fact, Trait("Category", "Integration")]
        public void TestListOperationsByStore()
        {
            var ímported = ImportOperations();

            var importedCount = ímported.SelectMany(d => d.Operations).Count();

            var operationService = new OperationService(new OperationRepository(DbContext));

            var list = operationService.ListOperationsByStore();

            Assert.Equal(importedCount, list.SelectMany(d => d.Operations).Count());
        }
    }
}
