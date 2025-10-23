using ByCodersChallengeDotNet.Core.Enums;
using System.Text.RegularExpressions;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public partial class Time(ReadOnlySpan<char> value) : OperationField<DateTime>(new(FieldType.Time, 0, 0, 14), value, GetSlice)
    {
        private static readonly Field DateField = new(FieldType.Date, 1, 8, 8);
        private static readonly Field TimeField = new(FieldType.Time, 42, 47, 6);

        private static new readonly Func<ReadOnlySpan<char>, ReadOnlySpan<char>> GetSlice = (_value) =>
        {
            int start = DateField.Start;
            int end = TimeField.End + 1;

            AssertSliceSize(FieldType.Time, start, end, _value);

            var date = _value[DateField.Start..(DateField.End + 1)];
            var time = _value[TimeField.Start..(TimeField.End + 1)];

            return string.Concat(date, time).AsSpan();
        };

        protected override void SetFieldValue(ReadOnlySpan<char> value)
        {
            var year = int.Parse(value[..4]);
            var month = int.Parse(value[4..6]);
            var day = int.Parse(value[6..8]);

            var hour = int.Parse(value[8..10]);
            var minute = int.Parse(value[10..12]);
            var second = int.Parse(value[12..]);

            Value = new DateTime(year, month, day, hour, minute, second);
        }

        public override bool ValidateField(ReadOnlySpan<char> value)
        {
            return TimeRegex().IsMatch(value);
        }

        [GeneratedRegex(@"^\d{14}$")]
        private static partial Regex TimeRegex();
    }
}
