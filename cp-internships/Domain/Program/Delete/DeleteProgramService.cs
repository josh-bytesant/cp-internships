using Domain.Shared;

namespace Domain.Program.Delete
{
    public class DeleteProgramService
    {
        private readonly IDeleteProgramRepository _deleteProgramRepository;

        public DeleteProgramService(IDeleteProgramRepository deleteProgramRepository)
        {
            _deleteProgramRepository = deleteProgramRepository;

        }

        
        public async Task<Result> Delete(string id, CancellationToken cancellationToken)
        {
            Result<int> result = await _deleteProgramRepository.Delete(id, cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }
            return Result.Success();
        }
    }
}
