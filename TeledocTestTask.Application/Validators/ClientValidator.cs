using FluentValidation;
using TeledocTestTask.Application.Commands.Clients.Base;
using TeledocTestTask.Domain.Enums;

namespace TeledocTestTask.Application.Validators
{
    public class ClientValidator : AbstractValidator<ClientBaseCommand>
    {
        public ClientValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("The name must be filled and contain less than 50 characters!");

            RuleFor(p => p.TaxpayerNumber)
                .NotEmpty()
                .WithMessage("The taxpayer number must be filled");

            RuleFor(p => p.ClientType)
                .IsInEnum()
                .WithMessage("Client type isn't defined properly!");

            When(p => !string.IsNullOrWhiteSpace(p.Name), () =>
            {
                RuleFor(p => p.Name)
                    .Must(name => char.IsUpper(name[0]))
                    .WithMessage("The first letter of name must be capital");
            });

            When(p => !string.IsNullOrWhiteSpace(p.TaxpayerNumber), () =>
            {
                RuleFor(p => p.TaxpayerNumber)
                    .Must(number => number.All(char.IsDigit))
                    .WithMessage("The taxpayer number can't contain letters!");

                When(p => p.ClientType == ClientType.LegalPerson, () =>
                {
                    RuleFor(p => p.TaxpayerNumber)
                        .Length(10)
                        .WithMessage("The valid length for legal person's taxpayer number is 10");
                });

                When(p => p.ClientType == ClientType.IndividualEntrepreneur, () =>
                {
                    RuleFor(p => p.TaxpayerNumber)
                        .Length(12)
                        .WithMessage("The valid length for individual entrepreneur's taxpayer number is 12");
                });
            });
        }
    }
}
