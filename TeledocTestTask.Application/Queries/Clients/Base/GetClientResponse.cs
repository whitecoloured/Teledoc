
using TeledocTestTask.Domain.Models;

namespace TeledocTestTask.Application.Queries.Clients.Base
{
    public record GetClientResponse(Guid Id, string Name, string TaxpayerNumber, string? ClientType);

    public static class GetClientResponseConverter
    {
        public static GetClientResponse ToDTO(this Client client)
        {
            return new(client.Id, client.Name, client.TaxpayerNumber, Enum.GetName(client.ClientType));
        }
    }
}
