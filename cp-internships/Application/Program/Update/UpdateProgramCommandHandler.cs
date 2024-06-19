using Domain.Program.Update;
using Domain.Shared;
using MediatR;

namespace Application.Program.UpdateProgram
{
    public class UpdateProgramCommandHandler : IRequestHandler<UpdateProgramCommand, Result>
    {
        private readonly UpdateProgramService _updateProgramService;

        public UpdateProgramCommandHandler(UpdateProgramService updateProgramService)
        {
            _updateProgramService = updateProgramService;
        }

        public async Task<Result> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            var result = await _updateProgramService.Update(request.Program, cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            return Result.Success();
        }
    }
}
