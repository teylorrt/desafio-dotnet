using ByCodersChallengeDotNet.Core.Entities;

namespace ByCodersChallengeDotNet.Core.Services
{
    public interface IOperationService
    {
        bool ImportOperations(Stream fileStream);
        IEnumerable<Operation> ListOperations();
    }
}
