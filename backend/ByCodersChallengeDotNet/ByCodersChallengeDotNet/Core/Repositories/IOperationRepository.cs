using ByCodersChallengeDotNet.Core.Entities;

namespace ByCodersChallengeDotNet.Core.Repositories
{
    public interface IOperationRepository
    {
        bool Save(IEnumerable<Operation> operations);
        IEnumerable<Operation> List();
    }
}
