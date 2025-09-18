

using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Application.Commands.Founders.Base;
using TeledocTestTask.Domain.Exceptions;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Application.Commands.Founders.EditFounder
{
    public class EditFounderCommandHandler : IRequestHandler<EditFounderCommand, Unit>
    {
        private readonly TeledocContext _context;
        private readonly IValidator<FounderBaseCommand> _validator;

        public EditFounderCommandHandler(TeledocContext context, IValidator<FounderBaseCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<Unit> Handle(EditFounderCommand request, CancellationToken cancellationToken)
        {
            var modelState = _validator.Validate(request.EditModel);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            var (name, surname, fatherName, taxpayerNumber) = request.EditModel;

            if (await _context.Founders.AnyAsync(p => p.TaxpayerNumber == taxpayerNumber && p.Id != request.FounderId, cancellationToken))
            {
                throw new BadRequestException("You can't create a founder with already existing taxpayer number");
            }

            await _context.Founders
                    .Where(p => p.Id == request.FounderId)
                    .ExecuteUpdateAsync(options =>
                    options
                    .SetProperty(p => p.Name, name)
                    .SetProperty(p => p.Surname, surname)
                    .SetProperty(p => p.FatherName, fatherName)
                    .SetProperty(p => p.TaxpayerNumber, taxpayerNumber)
                    .SetProperty(p => p.UpdatedDate, DateTime.Now),
                    cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
