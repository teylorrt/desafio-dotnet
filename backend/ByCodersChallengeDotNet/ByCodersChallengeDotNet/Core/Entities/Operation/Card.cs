using ByCodersChallengeDotNet.Core.Enums;
using System.Text.RegularExpressions;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public partial class Card(ReadOnlySpan<char> value) : OperationField<string>(new(FieldType.Card, 30, 41, 12), value)
    {
        public override void SetValue(ReadOnlySpan<char> value)
        {
            Value = value.ToString();
        }

        public override bool Validate(ReadOnlySpan<char> value)
        {
            return CardRegex().IsMatch(value);
        }

        [GeneratedRegex(@"^\d{4}\*{4}\d{4}$")]
        private static partial Regex CardRegex();
    }
}
