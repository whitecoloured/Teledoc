using MediatR;

namespace TeledocTestTask.Application.Commands.Clients.EditClient
{
    public record EditClientCommand(EditClientModel EditModel, Guid ClientId) : IRequest<Unit>;
}
