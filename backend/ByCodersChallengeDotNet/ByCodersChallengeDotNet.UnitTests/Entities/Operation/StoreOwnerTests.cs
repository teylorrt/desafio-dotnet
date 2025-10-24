using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class StoreOwnerTests : FieldTestsBase<StoreOwner, string>
    {
        public StoreOwnerTests() : base(FieldType.StoreOwner, "PL_HO_ST_OWNER", "MARCOS PEREIRA", "MARCOS PEREIRA")
        {
        }

        public override string GetInvalidValue()
        {
            return "              ";
        }
    }
}
