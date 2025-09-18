using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Application.Queries.Founders.Base;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Queries.Founders.GetClientsFounders
{
    public class GetClientsFoundersQueryHandler : IRequestHandler<GetClientsFoundersQuery, List<GetFounderResponse>>
    {
        private readonly TeledocContext _context;

        public GetClientsFoundersQueryHandler(TeledocContext context)
        {
            _context = context;
        }

        public async Task<List<GetFounderResponse>> Handle(GetClientsFoundersQuery request, CancellationToken cancellationToken)
        {
            var founders = await _context.Founders
                                    .AsNoTracking()
                                    .Where(p => p.ClientID == request.ClientId)
                                    .Select(p => p.ToDTO())
                                    .ToListAsync(cancellationToken);

            return founders;
        }
    }
}
