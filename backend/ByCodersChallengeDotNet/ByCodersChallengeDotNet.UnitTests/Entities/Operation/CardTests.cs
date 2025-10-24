
using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class CardTests : FieldTestsBase<Card, string>
    {
        public CardTests() : base(FieldType.Card, "PLCE_HO_CARD", @"6777\*\*\*\*1313", "6777****1313")
        {
        }

        public override string GetInvalidValue()
        {
            return "***A";
        }
    }
}
