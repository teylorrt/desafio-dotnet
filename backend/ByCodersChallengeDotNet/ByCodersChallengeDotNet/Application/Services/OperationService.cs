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

        public bool ImportOperations(string text)
        {
            IEnumerable<Operation> operations = [];

            var saved = _operationRepository.Save(operations);

            return saved;
        }

        public IEnumerable<Operation> ListOperations()
        {
            return _operationRepository.List();
        }
    }
}
