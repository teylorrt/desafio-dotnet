using ByCodersChallenge.Core.Entity;

namespace ByCodersChallenge.Core.Repository
{
    public interface IOperationRepository
    {
        bool Save(IEnumerable<Operation> operations);
        IEnumerable<Operation> List();
    }
}
