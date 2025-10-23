using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public class Value(ReadOnlySpan<char> value) : OperationField<decimal>(new(FieldType.Value, 9, 18, 10), value)
    {
        public override void SetValue(ReadOnlySpan<char> value)
        {
            decimal _value = decimal.Parse(value);

            Value = _value / 100.00m;
        }

        public override bool Validate(ReadOnlySpan<char> value)
        {
            return decimal.TryParse(value, out _);
        }
    }
}
