
using TeledocTestTask.Domain.Enums;

namespace TeledocTestTask.Application.Commands.Clients.Base
{
    public abstract record ClientBaseCommand(string Name, string TaxpayerNumber, ClientType ClientType);
}
