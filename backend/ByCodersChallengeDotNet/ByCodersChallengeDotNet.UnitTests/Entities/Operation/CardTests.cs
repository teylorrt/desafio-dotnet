
using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;
using ByCodersChallengeDotNet.Core.Exceptions;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class CardTests
    {
        private const string CardPlaceHolder = "PLCE_HO_CARD";
        private const string PlaceHolder = $"320190301000001220084515254073{CardPlaceHolder}172712MARCOS PEREIRAMERCADO DA AVENIDA";
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
            var card = new Card(PlaceHolder.Replace(CardPlaceHolder, ValidCard));

            Assert.Equal(ValidCard, card.Value);
        }

        [Fact, Trait("Category", "Unit")]
        public void TestInvalidValidCard()
        {
            var expectedMessage = new InvalidFieldException(FieldType.Card).Message;
            var caughtException = Assert.Throws<InvalidFieldException>(() => new Card(PlaceHolder.Replace("****", "***A")));

            Assert.Equal(expectedMessage, caughtException.Message);
        }
    }
}
