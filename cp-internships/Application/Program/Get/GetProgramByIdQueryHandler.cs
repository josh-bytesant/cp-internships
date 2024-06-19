using Domain.Program.Get;
using Domain.Shared;
using MediatR;

namespace Application.Program.GetProgramById
{
    public class GetProgramByIdQueryHandler : IRequestHandler<GetProgramByIdQuery, Result<GetProgramDTO>>
    {
        private readonly IGetProgramRepository _getProgramRepository;
        private readonly GetProgramByIdService _getProgramByIdService;

        public GetProgramByIdQueryHandler(IGetProgramRepository getProgramRepository, GetProgramByIdService getProgramByIdService)
        {
            _getProgramRepository = getProgramRepository;
            _getProgramByIdService = getProgramByIdService;
        }

        public async Task<Result<GetProgramDTO>> Handle(GetProgramByIdQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Id)) return Result.Failure<GetProgramDTO>(GetProgramByIdErrors.NoId);
            Result<GetProgramDTO> result = await _getProgramByIdService.GetProgramById(request.Id, cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<GetProgramDTO>(result.Error);
            }

            return Result.Success<GetProgramDTO>(result.Value);
        }
    }
}
