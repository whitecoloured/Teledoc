

using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Commands.Founders.DeleteFounder
{
    public class DeleteFounderCommandHandler : IRequestHandler<DeleteFounderCommand, Unit>
    {
        private readonly TeledocContext _context;

        public DeleteFounderCommandHandler(TeledocContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFounderCommand request, CancellationToken cancellationToken)
        {
            await _context.Founders
                    .Where(p => p.Id == request.Id)
                    .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
