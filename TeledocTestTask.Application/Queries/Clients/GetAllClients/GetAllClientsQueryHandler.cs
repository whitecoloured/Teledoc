using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Application.Queries.Clients.Base;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Queries.Clients.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<GetClientResponse>>
    {
        private readonly TeledocContext _context;

        public GetAllClientsQueryHandler(TeledocContext context)
        {
            _context = context;
        }

        public async Task<List<GetClientResponse>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _context.Clients
                                    .AsNoTracking()
                                    .Select(p => p.ToDTO())
                                    .ToListAsync(cancellationToken);

            return clients;
        }
    }
}
