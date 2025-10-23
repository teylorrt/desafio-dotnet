namespace ByCodersChallengeDotNet.Core.Models
{
    public class OperationGroupModel
    {
        public string Name { get; set; }
        public IEnumerable<OperationModel> Operations { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
