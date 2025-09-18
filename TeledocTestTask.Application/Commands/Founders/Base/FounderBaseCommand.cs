

namespace TeledocTestTask.Application.Commands.Founders.Base
{
    public abstract record FounderBaseCommand(string Name, string Surname, string FatherName, string TaxpayerNumber);
}
