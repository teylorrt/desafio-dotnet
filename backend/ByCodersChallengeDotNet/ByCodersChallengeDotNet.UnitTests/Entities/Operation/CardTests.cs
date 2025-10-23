
using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;
using ByCodersChallengeDotNet.Core.Exceptions;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class CardTests
    {
        [Fact, Trait("Category", "Unit")]
        public void TestInvalidSize()
        {
            var expectedMessage = new InvalidFieldException(FieldType.Card).Message;
            var caughtException = Assert.Throws<InvalidFieldException>(() => new Card("asdasdasd"));

            Assert.Equal(expectedMessage, caughtException.Message);
        }
    }
}
