
using TeledocTestTask.Domain.Models;

namespace TeledocTestTask.Application.Queries.Founders.Base
{
    public record GetFounderResponse(Guid Id, string Name, string Surname, string FatherName, string TaxpayerNumber);

    public static class GetFounderResponseConverter
    {
        public static GetFounderResponse ToDTO(this Founder founder)
        {
            return new(founder.Id, founder.Name, founder.Surname, founder.FatherName, founder.TaxpayerNumber);
        }
    }
}
