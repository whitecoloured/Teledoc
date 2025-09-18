

using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Application.Commands.Founders.Base;
using TeledocTestTask.Domain.Enums;
using TeledocTestTask.Domain.Exceptions;
using TeledocTestTask.Domain.Models;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Commands.Founders.AddFounder
{
    public class AddFounderCommandHandler : IRequestHandler<AddFounderCommand, Guid>
    {
        private readonly TeledocContext _context;
        private readonly IValidator<FounderBaseCommand> _validator;
        public AddFounderCommandHandler(TeledocContext context, IValidator<FounderBaseCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<Guid> Handle(AddFounderCommand request, CancellationToken cancellationToken)
        {
            var modelState = _validator.Validate(request);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            var (name, surname, fatherName, taxpayerNumber, clientId) = request;

            var client = await _context.Clients.FirstOrDefaultAsync(p => p.Id == clientId, cancellationToken)
                ?? throw new NotFoundException("The client wasn't found!");

            if (client.ClientType != ClientType.LegalPerson)
            {
                throw new BadRequestException("You can't create a founder as you are not a legal person!");
            }

            if (await _context.Founders.AnyAsync(p => p.TaxpayerNumber == taxpayerNumber,cancellationToken))
            {
                throw new BadRequestException("You can't create a founder with already existing taxpayer number");
            }

            var newFounder = Founder.Create(name, surname, fatherName, taxpayerNumber, client);

            await _context.Founders.AddAsync(newFounder, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return newFounder.Id;
        }
    }
}
