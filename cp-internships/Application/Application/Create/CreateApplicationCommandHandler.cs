using Application.Application.Create;
using AutoMapper;
using Domain.Application.Create;
using Domain.Program.Get;
using Domain.Shared;
using MediatR;

namespace Application.Application.CreateApplication
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, Result>
    {
        private readonly IGetProgramRepository _getProgramRepository;
        private readonly CreateApplicationService _createApplicationService;
        private readonly IMapper _mapper;

        public CreateApplicationCommandHandler(IGetProgramRepository getProgramRepository, CreateApplicationService createApplicationService, IMapper mapper)
        {
            _getProgramRepository = getProgramRepository;
            _createApplicationService = createApplicationService;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            var program = await _getProgramRepository.GetProgramById(request.Application.ProgramId, cancellationToken);
            if (program.IsFailure) return CreateApplicationErrors.ProgramNotFoundForApplication;

            var application = _mapper.Map<Domain.Application.Entities.Application>(request.Application);
            Result result = await _createApplicationService.Create(application, cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            return Result.Success();
        }
    }
}
