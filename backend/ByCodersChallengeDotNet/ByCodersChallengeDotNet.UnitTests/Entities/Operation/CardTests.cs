
using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;
using ByCodersChallengeDotNet.Core.Exceptions;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class CardTests
    {
        private const string ValidLine = "3201903010000012200845152540736777****1313172712MARCOS PEREIRAMERCADO DA AVENIDA";
        private const string ValidCard = "6777****1313";

        [Fact, Trait("Category", "Unit")]
        public void TestInvalidSize()
        {
            var expectedMessage = new InvalidFieldException(FieldType.Card).Message;
            var caughtException = Assert.Throws<InvalidFieldException>(() => new Card("asdasdasd"));

            Assert.Equal(expectedMessage, caughtException.Message);
        }

        [Fact, Trait("Category", "Unit")]
        public void TestValidCard()
        {
            var card = new Card(ValidLine);

            Assert.Equal(ValidCard, card.Value);
        }

        [Fact, Trait("Category", "Unit")]
        public void TestInvalidValidCard()
        {
            var expectedMessage = new InvalidFieldException(FieldType.Card).Message;
            var caughtException = Assert.Throws<InvalidFieldException>(() => new Card(ValidLine.Replace("****", "***A")));

            Assert.Equal(expectedMessage, caughtException.Message);
        }
    }
}
