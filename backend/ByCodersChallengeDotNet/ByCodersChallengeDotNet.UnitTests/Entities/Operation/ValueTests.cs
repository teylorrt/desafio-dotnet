using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class ValueTests : FieldTestsBase<Core.Entities.Operation.Value, decimal>
    {
        public ValueTests() : base(FieldType.Value, "PL_HO_VALU", @"0000012200", 122)
        {
        }

        public override string GetInvalidValue()
        {
            return "A";
        }
    }
}
