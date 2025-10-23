using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public class StoreOwner(ReadOnlySpan<char> value) : OperationField<string>(new(FieldType.StoreOwner, 48, 61, 14), value)
    {
        protected override void SetFieldValue(ReadOnlySpan<char> value)
        {
            Value = value.Trim().ToString();
        }

        protected override bool ValidateField(ReadOnlySpan<char> value)
        {
            return !string.IsNullOrWhiteSpace(value.Trim().ToString());
        }
    }
}
