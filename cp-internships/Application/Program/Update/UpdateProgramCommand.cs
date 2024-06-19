using Domain.Shared;
using MediatR;

namespace Application.Program.UpdateProgram
{
    public sealed record UpdateProgramCommand(Domain.Program.Entities.Program Program) : IRequest<Result>;
}
