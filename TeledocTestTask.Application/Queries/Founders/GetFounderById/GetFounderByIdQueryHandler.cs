

using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Application.Queries.Founders.Base;
using TeledocTestTask.Domain.Exceptions;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Queries.Founders.GetFounderById
{
    public class GetFounderByIdQueryHandler : IRequestHandler<GetFounderByIdQuery, GetFounderResponse>
    {
        private readonly TeledocContext _context;

        public GetFounderByIdQueryHandler(TeledocContext context)
        {
            _context = context;
        }

        public async Task<GetFounderResponse> Handle(GetFounderByIdQuery request, CancellationToken cancellationToken)
        {
            var founder = await _context.Founders
                                .AsNoTracking()
                                .Where(p => p.Id == request.Id)
                                .Select(p => p.ToDTO())
                                .FirstOrDefaultAsync(cancellationToken)
                                ?? throw new NotFoundException("The founder wasn't found!");

            return founder;
        }
    }
}
