using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities
{
    public class Operation
    {
        public long Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set;  }
        public decimal Value { get; set; }
        public long CPF { get; set; }
        public long Card {  get; set; }
        public int Time { get; set; }
        public string StoreOwner { get; set; }
        public string StoreName { get; set; }

        public bool SetField(FieldType fieldType, string value)
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

        private bool SetType(string value)
        {
            return true;
        }
        private bool SetDate(string value)
        {
            return true;
        }
        private bool SetValue(string value)
        {
            return true;
        }
        private bool SetCPF(string value)
        {
            return true;
        }
        private bool SetCard(string value)
        {
            return true;
        }
        private bool SetTime(string value)
        {
            return true;
        }
        private bool SetStoreOwner(string value)
        {
            return true;
        }
        private bool SetStoreName(string value)
        {
            return true;
        }
    }
}
