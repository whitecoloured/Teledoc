using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Commands.Clients.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
    {
        private readonly TeledocContext _context;
        public DeleteClientCommandHandler(TeledocContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await _context.Clients
                    .Where(p => p.Id == request.Id)
                    .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
