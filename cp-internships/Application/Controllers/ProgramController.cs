using Application.Program.Create;
using Application.Program.DeleteProgram;
using Application.Program.GetProgramById;
using Application.Program.UpdateProgram;
using Domain.Program.Create;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly ILogger<ProgramController> _logger;
        private readonly ISender _sender;
        public ProgramController(ILogger<ProgramController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        #region UtitlityEndpoint
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult GetTestData()
        {

            var program = Domain.Program.Entities.Program.Create();
            return Ok(program);
        }
        #endregion


        [HttpGet]
        public IActionResult GetQuestionTypes()
        {
            var types = Domain.Program.Entities.QuestionType.GetQuestionTypes;
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramById(
        string id,
        CancellationToken cancellationToken)
        {
            var command = new GetProgramByIdQuery(id);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                _logger.LogError(result.Error.SerializeThis());
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram(
        CreateProgramDTO program,
        CancellationToken cancellationToken)
        {
            var command = new CreateProgramCommand(program);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                _logger.LogError(result.Error.SerializeThis());
                return BadRequest(result.Error);
            }

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProgram(
        Domain.Program.Entities.Program program,
        CancellationToken cancellationToken)
        {
            var command = new UpdateProgramCommand(program);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                _logger.LogError(result.Error.SerializeThis());
                return BadRequest(result.Error);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(
        string id,
        CancellationToken cancellationToken)
        {
            var command = new DeleteProgramCommand(id);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                _logger.LogError(result.Error.SerializeThis());
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}
