using ByCodersChallenge.Core.Entity;
using ByCodersChallenge.Core.Repository;
using ByCodersChallenge.Core.Service;

namespace ByCodersChallenge.Application.Service
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public IEnumerable<Operation> ListOperations()
        {
            return _operationRepository.List();
        }
    }
}
