using MediatR;

namespace TeledocTestTask.Application.Commands.Clients.DeleteClient
{
    public record DeleteClientCommand(Guid Id) : IRequest<Unit>;
}
