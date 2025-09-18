using MediatR;
using TeledocTestTask.Application.Queries.Clients.Base;

namespace TeledocTestTask.Application.Queries.Clients.GetAllClients
{
    public record GetAllClientsQuery() : IRequest<List<GetClientResponse>>;
}
