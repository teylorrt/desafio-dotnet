using ByCodersChallengeDotNet.Application.Services;
using ByCodersChallengeDotNet.Infrastructure.Repositories;
using ByCodersChallengeDotNet.Presentation.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
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

        private readonly OperationController _operationController;
        public OperationTests()
        {
            _operationController = new OperationController(new OperationService(new OperationRepository(DbContext)));
        }

        public static string BuildRandomStoreName()
        {
            return BuildRandomStringWithNumbers(19);
        }

        private static IFormFile CreateStream(string placeHolder, string storeName)
        {
            var text = File.ReadAllText("CNAB.txt");

            text = Regex.Replace(text, placeHolder, storeName);

            MemoryStream ms = new();

            byte[] bytes = Encoding.UTF8.GetBytes(text);

            ms.Write(bytes, 0, bytes.Length);

            ms.Position = 0;

            var fileMock = new Mock<IFormFile>();

            fileMock.Setup(f => f.FileName).Returns("CNAB.txt");
            fileMock.Setup(f => f.Length).Returns(ms.Length);
            fileMock.Setup(f => f.OpenReadStream()).Returns(ms);
            fileMock.Setup(f => f.ContentType).Returns("text/plain");

            return fileMock.Object;
        }

        private async Task ImportOperations(string placeHolder, string storeName)
        {
            var formFile = CreateStream(placeHolder, storeName);

            var result = (OkObjectResult) await _operationController.Import(formFile);

            var expected = _operationController.Ok("SUCCESS");

            Assert.Equal(expected.StatusCode, result.StatusCode);
            Assert.Equal(expected.Value, result.Value);
        }

        [Fact, Trait("Category", "Integration")]
        public async Task TestImportOperations()
        {
            var storeName = BuildRandomStoreName();

            //replace all place holders
            await ImportOperations(@"PLACE_HOLDER_STORE\d", storeName);

            var operations = await _operationController.LisByStoreName(storeName);

            Assert.Equal(21, operations.Count());

            foreach (var item in operations)
            {
                Assert.Equal(storeName, item.StoreName);
            }
        }

        [Fact, Trait("Category", "Integration")]
        public async Task TestListOperationsByStore()
        {
            var storeName = BuildRandomStoreName();

            await ImportOperations(PlaceHolderStore3, storeName);

            var list = await _operationController.LisByStoreName(storeName);

            Assert.Equal(4, list.Count());
        }
    }
}
