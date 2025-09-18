using TeledocTestTask.Domain.Enums;


namespace TeledocTestTask.Domain.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string TaxpayerNumber { get; set; }
        public ClientType ClientType { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Founder>? Founders { get; set; }

        public static Client Create(string Name, string TaxpayerNumber, ClientType ClientType)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                TaxpayerNumber = TaxpayerNumber,
                ClientType = ClientType,
                AddedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

        }
    }
}
