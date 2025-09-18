using MediatR;
using TeledocTestTask.Application.Queries.Founders.Base;

namespace TeledocTestTask.Application.Queries.Founders.GetFounderById
{
    public record GetFounderByIdQuery(Guid Id) : IRequest<GetFounderResponse>;
}
