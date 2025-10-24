using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class StoreNameTests : FieldTestsBase<StoreName, string>
    {
        public StoreNameTests() : base(FieldType.StoreName, "PLACE_HOLD_ST_NAME", "MERCADO DA AVENIDA", "MERCADO DA AVENIDA")
        {
        }

        public override string GetInvalidValue()
        {
            return "";
        }
    }
}
