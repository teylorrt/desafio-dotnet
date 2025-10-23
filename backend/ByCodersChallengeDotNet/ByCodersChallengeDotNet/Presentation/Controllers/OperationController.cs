using ByCodersChallengeDotNet.Core.Models;
using ByCodersChallengeDotNet.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ByCodersChallengeDotNet.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                _operationService.ImportOperations(stream);
            }

            return Ok("SUCCESS");
        }

        [HttpGet("list-by-store")]
        public IEnumerable<OperationGroupModel> ListOperationsByStore()
        {
            return _operationService.ListOperationsByStore();
        }
    }
}
