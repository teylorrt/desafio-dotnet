using ByCodersChallenge.Core.Entity;

namespace ByCodersChallenge.Core.Service
{
    public interface IOperationService
    {
        IEnumerable<Operation> ListOperations();
    }
}
