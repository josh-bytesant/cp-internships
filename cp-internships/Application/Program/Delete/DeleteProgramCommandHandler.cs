using Domain.Program.Delete;
using Domain.Shared;
using MediatR;

namespace Application.Program.DeleteProgram
{
    public class DeleteProgramCommandHandler : IRequestHandler<DeleteProgramCommand, Result>
    {
        private readonly DeleteProgramService _deleteProgramService;

        public DeleteProgramCommandHandler(DeleteProgramService deleteProgramService)
        {
            _deleteProgramService = deleteProgramService;
        }

        public async Task<Result> Handle(DeleteProgramCommand request, CancellationToken cancellationToken)
        {
            var result = await _deleteProgramService.Delete(request.Id, cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }
            return Result.Success();
        }
    }
}
