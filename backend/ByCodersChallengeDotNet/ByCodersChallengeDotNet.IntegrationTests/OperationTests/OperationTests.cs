using ByCodersChallengeDotNet.Application.Services;
using ByCodersChallengeDotNet.Core.Services;
using ByCodersChallengeDotNet.Infrastructure.Repositories;
using System.Text;
using System.Text.RegularExpressions;

namespace ByCodersChallengeDotNet.IntegrationTests.OperationTests
{
    public class OperationTests : IntegrationTestBase
    {
        private const string PlaceHolderStore1 = "PLACE_HOLDER_STORE1";
        private const string PlaceHolderStore2 = "PLACE_HOLDER_STORE2";
        private const string PlaceHolderStore3 = "PLACE_HOLDER_STORE3";
        private const string PlaceHolderStore4 = "PLACE_HOLDER_STORE4";

        private readonly IOperationService _operationService;
        public OperationTests()
        {
            _operationService = new OperationService(new OperationRepository(DbContext));
        }

        public static string BuildRandomStoreName()
        {
            return BuildRandomStringWithNumbers(19);
        }

        private static MemoryStream CreateStream(string placeHolder, string storeName)
        {
            var text = System.IO.File.ReadAllText("CNAB.txt");

            text = Regex.Replace(text, placeHolder, storeName);

            MemoryStream ms = new();

            byte[] bytes = Encoding.UTF8.GetBytes(text);

            ms.Write(bytes, 0, bytes.Length);

            ms.Position = 0;
            return ms;
        }

        private void ImportOperations(string placeHolder, string storeName)
        {
            var stream = CreateStream(placeHolder, storeName);
            
            var imported = _operationService.ImportOperations(stream);

            Assert.True(imported);
        }

        [Fact, Trait("Category", "Integration")]
        public void TestImportOperations()
        {
            var storeName = BuildRandomStoreName();

            //replace all place holders
            ImportOperations(@"PLACE_HOLDER_STORE\d", storeName);

            var list = _operationService.ListOperationsGroupedByStore();

            var operations = _operationService.ListByStoreName(storeName);

            Assert.Equal(21, operations.Count());

            foreach (var item in operations)
            {
                Assert.Equal(storeName, item.StoreName);
            }
        }

        [Fact, Trait("Category", "Integration")]
        public void TestListOperationsByStore()
        {
            var storeName = BuildRandomStoreName();
            ImportOperations(PlaceHolderStore3, storeName);

            var operationService = new OperationService(new OperationRepository(DbContext));

            var list = operationService.ListByStoreName(storeName);

            Assert.Equal(4, list.Count());
        }
    }
}
