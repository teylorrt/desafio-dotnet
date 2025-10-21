using ByCodersChallenge.Core.Entity;
using ByCodersChallenge.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace ByCodersChallenge.Presentation.Controller
{
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet("list-operations")]
        public IEnumerable<Operation> ListOperations()
        {
            return _operationService.ListOperations();
        }
    }
}
