using Domain.Program.Get;
using Domain.Shared;
using MediatR;

namespace Application.Program.GetProgramById
{
    public record GetProgramByIdQuery(string Id) : IRequest<Result<GetProgramDTO>>;
}
