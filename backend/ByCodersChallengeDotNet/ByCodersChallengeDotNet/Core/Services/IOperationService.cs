using ByCodersChallengeDotNet.Core.Entities;
using ByCodersChallengeDotNet.Core.Models;

namespace ByCodersChallengeDotNet.Core.Services
{
    public interface IOperationService
    {
        bool ImportOperations(Stream fileStream);
        IEnumerable<OperationGroupModel> ListOperationsByStore();
    }
}
