using Domain.Shared;

namespace Domain.Program.Get
{
    public class GetProgramByIdService
    {
        private readonly IGetProgramRepository _getProgramRepository;

        public GetProgramByIdService(IGetProgramRepository getProgramRepository)
        {
            _getProgramRepository = getProgramRepository;
        }

        public async Task<Result<GetProgramDTO>> GetProgramById(string id, CancellationToken cancellationToken)
        {
            Result<GetProgramDTO> result = await _getProgramRepository.GetProgramById(id, cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<GetProgramDTO>(result.Error);
            }
            return Result.Success<GetProgramDTO>(result.Value);
        }
    }
}
