using Domain.Application.Create;
using Domain.Shared;
using MediatR;

namespace Application.Application.Create
{
    public sealed record CreateApplicationCommand(CreateApplicationDTO Application) : IRequest<Result>;
}
