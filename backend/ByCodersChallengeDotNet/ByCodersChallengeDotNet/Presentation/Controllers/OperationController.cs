using ByCodersChallengeDotNet.Core.Entities;
using ByCodersChallengeDotNet.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ByCodersChallengeDotNet.Presentation.Controllers
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
