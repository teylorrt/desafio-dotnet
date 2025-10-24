using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class TypeTests : FieldTestsBase<Core.Entities.Operation.Type, int>
    {
        public TypeTests() : base(FieldType.Type, "PL_TYPE", @"^3", 3)
        {
        }

        public override string GetInvalidValue()
        {
            return "A";
        }
    }
}
