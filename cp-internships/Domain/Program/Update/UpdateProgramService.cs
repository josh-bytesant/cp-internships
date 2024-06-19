using Domain.Program.Get;
using Domain.Program.Shared;
using Domain.Shared;


namespace Domain.Program.Update
{
    public class UpdateProgramService
    {
        private readonly IUpsertProgramRepository _upsertProgramRepository;

        public UpdateProgramService(IUpsertProgramRepository upsertProgramRepository)
        {
            _upsertProgramRepository = upsertProgramRepository;
        }

        public async Task<Result> Update(Domain.Program.Entities.Program program, CancellationToken cancellationToken)
        {
            Result<int> result = await _upsertProgramRepository.Upsert(program, cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure<GetProgramDTO>(result.Error);
            }

            if (result.Value != 200) return UpdateProgramErrors.ErrorUpdatingProgram;
            return Result.Success();
        }
    }
}
