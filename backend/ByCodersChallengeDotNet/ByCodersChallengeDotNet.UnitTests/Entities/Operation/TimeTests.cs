using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class TimeTests : FieldTestsBase<Time, DateTime>
    {
        public TimeTests() : base(FieldType.Time, "PL_HO_TM", "20190301", new DateTime(2019, 3, 1, 17, 27, 12))
        {
        }

        public override string GetInvalidValue()
        {
            return "AAAAAAAAA";
        }
    }
}
