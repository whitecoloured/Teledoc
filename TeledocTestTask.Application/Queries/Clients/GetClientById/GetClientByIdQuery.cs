using MediatR;
using TeledocTestTask.Application.Queries.Clients.Base;

namespace TeledocTestTask.Application.Queries.Clients.GetClientById
{
    public record GetClientByIdQuery(Guid Id) : IRequest<GetClientResponse>;
}
