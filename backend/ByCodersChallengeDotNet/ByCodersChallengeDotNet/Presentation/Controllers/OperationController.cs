using ByCodersChallengeDotNet.Core.Entities;
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

            return Ok("File uploaded successfully.");
        }

        [HttpGet("list")]
        public IEnumerable<Operation> ListOperations()
        {
            return _operationService.ListOperations();
        }
    }
}
