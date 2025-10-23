using ByCodersChallengeDotNet.Core.Enums;
using ByCodersChallengeDotNet.Core.Exceptions;
using System.Text.RegularExpressions;

namespace ByCodersChallengeDotNet.Core.Entities
{
    public partial class Operation
    {
        public long Id { get; set; }
        public TransactionType Type { get; set; }
        public int TypeId { get; set; }
        public DateOnly Date { get; set;  }
        public decimal Value { get; set; }
        public long CPF { get; set; }
        public string Card {  get; set; }
        public int Time { get; set; }
        public string StoreOwner { get; set; }
        public string StoreName { get; set; }

        public bool SetField(FieldType fieldType, ReadOnlySpan<char> value)
        {
            return fieldType switch
            {
                FieldType.Type => SetType(value),
                FieldType.Date => SetDate(value),
                FieldType.Value => SetValue(value),
                FieldType.CPF => SetCPF(value),
                FieldType.Card => SetCard(value),
                FieldType.Time => SetTime(value),
                FieldType.StoreOwner => SetStoreOwner(value),
                FieldType.StoreName => SetStoreName(value),
                _ => false,
            };
        }

        private bool SetType(ReadOnlySpan<char> value)
        {
            AssertFieldSize(FieldType.Type, 1, value);

            TypeId = int.Parse(value);
            return true;
        }
        private bool SetDate(ReadOnlySpan<char> value)
        {
            AssertFieldSize(FieldType.Date, 8, value);

            int year = int.Parse(value[..4]);
            int month = int.Parse(value[4..6]);
            int day = int.Parse(value[6..]);
            Date = new DateOnly(year, month, day);

            return true;
        }
        private bool SetValue(ReadOnlySpan<char> value)
        {
            AssertFieldSize(FieldType.Value, 10, value);
            decimal _value = decimal.Parse(value);

            Value = _value / 100.00m;
            return true;
        }
        private bool SetCPF(ReadOnlySpan<char> value)
        {
            AssertFieldSize(FieldType.CPF, 11, value);
            CPF = long.Parse(value);
            return true;
        }
        private bool SetCard(ReadOnlySpan<char> value)
        {
            AssertFieldSize(FieldType.Card, 12, value);
            var _card = value.ToString();

            if (!CardRegex().IsMatch(_card))
            {
                throw new InvalidFieldException(FieldType.Card);
            }

            Card = value.ToString();
            return true;
        }
        private bool SetTime(ReadOnlySpan<char> value)
        {
            AssertFieldSize(FieldType.Time, 6, value);
            return true;
        }
        private bool SetStoreOwner(ReadOnlySpan<char> value)
        {
            AssertFieldSize(FieldType.StoreOwner, 14, value);
            StoreOwner = value.ToString();
            return true;
        }
        private bool SetStoreName(ReadOnlySpan<char> value)
        {
            AssertFieldSize(FieldType.StoreName, 18, value);
            StoreName = value.ToString();
            return true;
        }

        private static void AssertFieldSize(FieldType fieldType, int size, ReadOnlySpan<char> value)
        {
            if (value.Length != size)
            {
                throw new InvalidFieldException(fieldType);
            }
        }

        [GeneratedRegex(@"^\d{4}\*{4}\d{4}$")]
        private static partial Regex CardRegex();
    }
}
