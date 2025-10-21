using ByCodersChallenge.Core.Entity;

namespace ByCodersChallenge.Core.Service
{
    public interface IOperationService
    {
        bool ImportOperations(string text);
        IEnumerable<Operation> ListOperations();
    }
}
