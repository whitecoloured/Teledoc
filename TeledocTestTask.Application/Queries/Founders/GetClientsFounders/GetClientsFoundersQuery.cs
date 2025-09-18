

using MediatR;
using TeledocTestTask.Application.Queries.Founders.Base;

namespace TeledocTestTask.Application.Queries.Founders.GetClientsFounders
{
    public record GetClientsFoundersQuery(Guid ClientId) : IRequest<List<GetFounderResponse>>;
}
