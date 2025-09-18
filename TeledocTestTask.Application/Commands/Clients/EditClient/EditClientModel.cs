using TeledocTestTask.Application.Commands.Clients.Base;
using TeledocTestTask.Domain.Enums;

namespace TeledocTestTask.Application.Commands.Clients.EditClient
{
    public record EditClientModel(string Name, string TaxpayerNumber, ClientType ClientType) : ClientBaseCommand(Name, TaxpayerNumber, ClientType);
}
