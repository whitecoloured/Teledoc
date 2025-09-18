using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeledocTestTask.Domain.Models;


namespace TeledocTestTask.Infrastructure.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.TaxpayerNumber)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(p => p.ClientType)
                .HasConversion<int>();

            builder
                .HasMany(p => p.Founders)
                .WithOne(p => p.Client);

            builder
                .HasIndex(p => p.TaxpayerNumber)
                .IsUnique();
        }
    }
}
