using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public class CpfTests : FieldTestsBase<Cpf, long>
    {
        public CpfTests() : base(FieldType.Cpf, "PLCE_HO_CPF", "84515254073", 84515254073)
        {
        }

        public override string GetInvalidValue()
        {
            var invalidValue = ValidValue.ToCharArray();

            invalidValue[0] = 'A';

            return invalidValue.ToString();
        }
    }
}
