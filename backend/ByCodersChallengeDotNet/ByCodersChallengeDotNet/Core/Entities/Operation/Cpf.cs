using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public class Cpf(ReadOnlySpan<char> value) : OperationField<long>(new(FieldType.Cpf, 19, 29, 11), value)
    {
        public override void SetValue(ReadOnlySpan<char> value)
        {
            Value = long.Parse(value);
        }

        public override bool Validate(ReadOnlySpan<char> value)
        {
            return long.TryParse(value, out _);
        }
    }
}
