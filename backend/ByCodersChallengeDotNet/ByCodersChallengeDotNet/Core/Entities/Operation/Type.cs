using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public class Type(ReadOnlySpan<char> value) : OperationField<int>(new(FieldType.Type, 0, 0, 1), value)
    {
        protected override void SetFieldValue(ReadOnlySpan<char> value)
        {
            Value = int.Parse(value);
        }

        public override bool ValidateField(ReadOnlySpan<char> value)
        {
            return int.TryParse(value, out _);
        }
    }
}
