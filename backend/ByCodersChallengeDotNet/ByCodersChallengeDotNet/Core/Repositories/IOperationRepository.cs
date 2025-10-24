using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Models;

namespace ByCodersChallengeDotNet.Core.Repositories
{
    public interface IOperationRepository
    {
        bool Save(IEnumerable<Operation> operations);
        IEnumerable<OperationModel> List();
        IEnumerable<OperationModel> List(string name);
    }
}
