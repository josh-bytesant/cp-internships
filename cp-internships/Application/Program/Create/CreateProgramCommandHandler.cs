using AutoMapper;
using Domain.Program.Create;
using Domain.Shared;
using MediatR;

namespace Application.Program.Create
{
    public class CreateProgramCommandHandler : IRequestHandler<CreateProgramCommand, Result>
    {
        private readonly CreateProgramService _createProgramService;
        private readonly IMapper _mapper;

        public CreateProgramCommandHandler(CreateProgramService createProgramService, IMapper mapper)
        {
            _createProgramService = createProgramService;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {
            var program = _mapper.Map<Domain.Program.Entities.Program>(request.Program);
            Result result = await _createProgramService.Create(program, cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            return Result.Success();
        }
    }
}
