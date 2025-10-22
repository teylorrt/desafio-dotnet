using ByCodersChallengeDotNet.Core.Entities;

namespace ByCodersChallengeDotNet.Core.Services
{
    public interface IOperationService
    {
        bool ImportOperations(string text);
        IEnumerable<Operation> ListOperations();
    }
}
