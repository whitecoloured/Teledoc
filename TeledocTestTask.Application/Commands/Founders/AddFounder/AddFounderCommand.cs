using MediatR;
using TeledocTestTask.Application.Commands.Founders.Base;

namespace TeledocTestTask.Application.Commands.Founders.AddFounder
{
    public record AddFounderCommand(string Name, string Surname, string FatherName, string TaxpayerNumber, Guid ClientId) : FounderBaseCommand(Name, Surname, FatherName, TaxpayerNumber), IRequest<Guid>;
}
