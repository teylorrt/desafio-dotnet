using ByCodersChallenge.Core.Entity;

namespace ByCodersChallenge.Core.Repository
{
    public interface IOperationRepository
    {
        IEnumerable<Operation> List();
    }
}
