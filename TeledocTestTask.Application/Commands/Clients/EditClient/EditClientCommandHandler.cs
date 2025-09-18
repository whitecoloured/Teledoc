using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Application.Commands.Clients.Base;
using TeledocTestTask.Domain.Exceptions;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Commands.Clients.EditClient
{
    public class EditClientCommandHandler : IRequestHandler<EditClientCommand, Unit>
    {
        private readonly TeledocContext _context;
        private readonly IValidator<ClientBaseCommand> _validator;
        public EditClientCommandHandler(TeledocContext context, IValidator<ClientBaseCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Unit> Handle(EditClientCommand request, CancellationToken cancellationToken)
        {
            var modelState = _validator.Validate(request.EditModel);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            var (name, taxpayerNumber, clientType) = request.EditModel;

            if (await _context.Clients.AnyAsync(p => p.TaxpayerNumber == taxpayerNumber && p.Id != request.ClientId))
            {
                throw new BadRequestException("You can't register the client with already existing taxpayer number");
            }

            await _context.Clients
                    .Where(p => p.Id == request.ClientId)
                    .ExecuteUpdateAsync(options =>
                    options
                    .SetProperty(p => p.Name, name)
                    .SetProperty(p => p.TaxpayerNumber, taxpayerNumber)
                    .SetProperty(p => p.ClientType, clientType)
                    .SetProperty(p => p.UpdatedDate, DateTime.Now),
                    cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
