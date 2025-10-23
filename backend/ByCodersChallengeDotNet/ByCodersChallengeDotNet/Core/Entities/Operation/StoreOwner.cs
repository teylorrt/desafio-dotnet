using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public class StoreOwner(ReadOnlySpan<char> value) : OperationField<string>(new(FieldType.StoreOwner, 48, 61, 14), value)
    {
        public override void SetValue(ReadOnlySpan<char> value)
        {
            Value = value.Trim().ToString();
        }

        public override bool Validate(ReadOnlySpan<char> value)
        {
            return !string.IsNullOrWhiteSpace(value.Trim().ToString());
        }
    }
}
