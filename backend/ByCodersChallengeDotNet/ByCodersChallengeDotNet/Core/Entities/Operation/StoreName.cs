using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public class StoreName(ReadOnlySpan<char> value) : OperationField<string>(Field, value, GetSlice)
    {
        private static new readonly Field Field = new(FieldType.StoreName, 62, 80, 18);

        private static new readonly Func<ReadOnlySpan<char>, ReadOnlySpan<char>> GetSlice = (_value) =>
        {
            AssertSliceSize(Field.Type, Field.Start, Field.End, _value);

            return _value[Field.Start..Field.End];
        };

        protected override void SetFieldValue(ReadOnlySpan<char> value)
        {
            Value = value.Trim().ToString();
        }

        public override bool ValidateField(ReadOnlySpan<char> value)
        {
            return !string.IsNullOrWhiteSpace(value.Trim().ToString());
        }
    }
}
