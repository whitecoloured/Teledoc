

using TeledocTestTask.Application.Commands.Founders.Base;

namespace TeledocTestTask.Application.Commands.Founders.EditFounder
{
    public record EditFounderModel(string Name, string Surname, string FatherName, string TaxpayerNumber) : FounderBaseCommand(Name, Surname, FatherName, TaxpayerNumber);
}
