

using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Application.Queries.Clients.Base;
using TeledocTestTask.Domain.Exceptions;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Queries.Clients.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, GetClientResponse>
    {
        private readonly TeledocContext _context;

        public GetClientByIdQueryHandler(TeledocContext context)
        {
            _context = context;
        }

        public async Task<GetClientResponse> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients
                                .AsNoTracking()
                                .Where(p => p.Id == request.Id)
                                .Select(p => p.ToDTO())
                                .FirstOrDefaultAsync(cancellationToken)
                                ?? throw new NotFoundException("The client wasn't found!");

            return client;
                                 
        }
    }
}
