using Domain.Program.Create;
using Domain.Shared;
using MediatR;

namespace Application.Program.Create
{
    public sealed record CreateProgramCommand(CreateProgramDTO Program) : IRequest<Result>;
}
