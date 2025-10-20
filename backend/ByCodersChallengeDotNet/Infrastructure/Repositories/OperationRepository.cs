using ByCodersChallenge.Core.Entity;
using ByCodersChallenge.Core.Repository;

namespace ByCodersChallenge.Infrastructure.Repository
{
    public class OperationRepository : IOperationRepository
    {
        public IEnumerable<Operation> List()
        {
            return [];
        }
    }
}
