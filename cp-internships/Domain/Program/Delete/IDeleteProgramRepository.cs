using Domain.Shared;

namespace Domain.Program.Delete
{
    public interface IDeleteProgramRepository
    {
        Task<Result<int>> Delete(string id, CancellationToken cancellationToken);
    }
}