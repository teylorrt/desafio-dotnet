using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public class Cpf(ReadOnlySpan<char> value) : OperationField<long>(new(FieldType.Cpf, 19, 29, 11), value)
    {
        protected override void SetFieldValue(ReadOnlySpan<char> value)
        {
            Value = long.Parse(value);
        }

        protected override bool ValidateField(ReadOnlySpan<char> value)
        {
            return long.TryParse(value, out _);
        }
    }
}
