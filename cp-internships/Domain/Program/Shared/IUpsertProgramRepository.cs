using Domain.Shared;

namespace Domain.Program.Shared
{
    public interface IUpsertProgramRepository
    {
        Task<Result<int>> Upsert(Domain.Program.Entities.Program program, CancellationToken cancellationToken);
    }
}