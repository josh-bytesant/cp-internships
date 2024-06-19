using Domain.Shared;

namespace Domain.Application.Create
{
    public interface ICreateApplicationRepository
    {
        Task<Result> Create(Domain.Application.Entities.Application application, CancellationToken cancellationToken);
    }
}
