using FluentValidation;
using TeledocTestTask.Application.Commands.Founders.Base;

namespace TeledocTestTask.Application.Validators
{
    public class FounderValidator : AbstractValidator<FounderBaseCommand>
    {
        public FounderValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("The name must be filled and contain less than 50 characters!");

            RuleFor(p => p.Surname)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("The surname must be filled and contain less than 100 characters!");

            RuleFor(p => p.FatherName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("The father name must be filled and contain less than 50 characters!");

            RuleFor(p => p.TaxpayerNumber)
                .NotEmpty()
                .Length(10)
                .WithMessage("The taxpayer number must be filled");

            When(p => !string.IsNullOrWhiteSpace(p.Name), () =>
            {
                RuleFor(p => p.Name)
                    .Must(p => char.IsUpper(p[0]))
                    .WithMessage("The first letter of name must be capital!");
            });

            When(p => !string.IsNullOrWhiteSpace(p.Surname), () =>
            {
                RuleFor(p => p.Surname)
                    .Must(p => char.IsUpper(p[0]))
                    .WithMessage("The first letter of surname must be capital!");
            });

            When(p => !string.IsNullOrWhiteSpace(p.FatherName), () =>
            {
                RuleFor(p => p.FatherName)
                    .Must(p => char.IsUpper(p[0]))
                    .WithMessage("The first letter of father name must be capital!");
            });

            When(p => !string.IsNullOrWhiteSpace(p.TaxpayerNumber), () =>
            {
                RuleFor(p => p.TaxpayerNumber)
                    .Must(p => p.All(char.IsDigit))
                    .WithMessage("The taxpayer number can't contain letters!");
            });
        }
    }
}
