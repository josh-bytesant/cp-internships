using Application.Application.Create;
using Domain.Application.Create;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ProgramController> _logger;
        private readonly ISender _sender;
        public ApplicationController(ILogger<ProgramController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(
        CreateApplicationDTO application,
        CancellationToken cancellationToken)
        {
            var command = new CreateApplicationCommand(application);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                _logger.LogError(result.Error.SerializeThis());
                return BadRequest(result.Error);
            }

            return Created();
        }
    }
}
