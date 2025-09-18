using MediatR;
using TeledocTestTask.Application.Commands.Clients.Base;
using TeledocTestTask.Domain.Enums;

namespace TeledocTestTask.Application.Commands.Clients.AddClient
{
    public record AddClientCommand(string Name, string TaxpayerNumber, ClientType ClientType) : ClientBaseCommand(Name, TaxpayerNumber, ClientType), IRequest<Guid>;
}
