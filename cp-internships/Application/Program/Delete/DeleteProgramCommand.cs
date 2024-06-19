using Domain.Shared;
using MediatR;

namespace Application.Program.DeleteProgram
{
    public sealed record DeleteProgramCommand(string Id) : IRequest<Result>;
}
