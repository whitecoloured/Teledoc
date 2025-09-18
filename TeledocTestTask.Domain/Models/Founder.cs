
namespace TeledocTestTask.Domain.Models
{
    public class Founder
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string FatherName { get; set; }
        public required string TaxpayerNumber { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid? ClientID { get; set; }
        public virtual Client? Client { get; set; }

        public static Founder Create(string Name, string Surname, string FatherName, string TaxpayerNumber, Client Client)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Surname = Surname,
                FatherName = FatherName,
                TaxpayerNumber = TaxpayerNumber,
                AddedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Client = Client
            };
        }
    }
}
