using Domain.Shared;

namespace Domain.Program.Get
{
    public interface IGetProgramRepository
    {
        Task<Result<GetProgramDTO>> GetProgramById(string id, CancellationToken cancellationToken);
    }
}