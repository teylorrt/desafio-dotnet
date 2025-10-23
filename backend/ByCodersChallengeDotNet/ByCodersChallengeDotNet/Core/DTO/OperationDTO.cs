using ByCodersChallengeDotNet.Core.Entities;
using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Models
{
    public class OperationDTO
    {
        public long Id { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }

        private string _nature;
        public string Nature { get { return _nature; } set { _nature = ((TransactionNature)value[0]).ToString(); } }
        public string Sign { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public long CPF { get; set; }
        public string Card { get; set; }
        public TimeSpan Time { get; set; }
        public string StoreOwner { get; set; }
        public string StoreName { get; set; }
    }
}
