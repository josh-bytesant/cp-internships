using Domain.Shared;

namespace Domain.Application.Create
{
    public class CreateApplicationService
    {
        private readonly ICreateApplicationRepository _createApplicationRepository;

        public CreateApplicationService(ICreateApplicationRepository createApplicationRepository)
        {
            _createApplicationRepository = createApplicationRepository;
        }

        public async Task<Result> Create(Domain.Application.Entities.Application application, CancellationToken cancellationToken)
        {
            Result result = await _createApplicationRepository.Create(application, cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }
            return Result.Success();
        }
    }
}
