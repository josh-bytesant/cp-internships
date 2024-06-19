using Domain.Program.Get;
using Domain.Program.Shared;
using Domain.Shared;

namespace Domain.Program.Create
{
    public class CreateProgramService
    {
        private readonly IUpsertProgramRepository _upsertProgramRepository;

        public CreateProgramService(IUpsertProgramRepository upsertProgramRepository)
        {
            _upsertProgramRepository = upsertProgramRepository;
        }

        public async Task<Result> Create(Domain.Program.Entities.Program program, CancellationToken cancellationToken)
        {
            Result<int> result = await _upsertProgramRepository.Upsert(program, cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<GetProgramDTO>(result.Error);
            }
            
            if (result.Value != 201) return CreateProgramErrors.ErrorCreatingProgram;
            return Result.Success();
        }
    }
}
