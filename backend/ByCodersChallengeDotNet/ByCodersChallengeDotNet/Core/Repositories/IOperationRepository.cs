using ByCodersChallengeDotNet.Core.Entities;
using ByCodersChallengeDotNet.Core.Models;

namespace ByCodersChallengeDotNet.Core.Repositories
{
    public interface IOperationRepository
    {
        bool Save(IEnumerable<Operation> operations);
        IEnumerable<OperationDTO> List();
    }
}
