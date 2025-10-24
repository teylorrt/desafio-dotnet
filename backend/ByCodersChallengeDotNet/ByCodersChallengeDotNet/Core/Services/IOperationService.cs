using ByCodersChallengeDotNet.Core.Models;

namespace ByCodersChallengeDotNet.Core.Services
{
    public interface IOperationService
    {
        bool ImportOperations(Stream fileStream);
        IEnumerable<OperationGroupModel> ListOperationsGroupedByStore();
        IEnumerable<OperationModel> ListByStoreName(string name);
    }
}
