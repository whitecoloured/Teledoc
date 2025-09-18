using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Application.Commands.Clients.Base;
using TeledocTestTask.Domain.Exceptions;
using TeledocTestTask.Domain.Models;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Commands.Clients.AddClient
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, Guid>
    {
        private readonly TeledocContext _context;
        private readonly IValidator<ClientBaseCommand> _validator;

        public AddClientCommandHandler(TeledocContext context, IValidator<ClientBaseCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<Guid> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var modelState = _validator.Validate(request);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            var (name, taxpayerNumber, clientType) = request;

            if (await _context.Clients.AnyAsync(p => p.TaxpayerNumber == taxpayerNumber))
            {
                throw new BadRequestException("You can't register the client with already existing taxpayer number");
            }

            var newClient = Client.Create(name, taxpayerNumber, clientType);

            await _context.Clients.AddAsync(newClient, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return newClient.Id;
        }
    }
}
