using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities
{
    public class TransactionType
    {
        public int Type { get; set; }
        public required string Description { get; set; }
        public TransactionNature Nature { get; set; }
        public TransactionSign Sign { get; set; }
    }
}
