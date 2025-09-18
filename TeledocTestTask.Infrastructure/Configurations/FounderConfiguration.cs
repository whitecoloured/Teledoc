using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeledocTestTask.Domain.Models;

namespace TeledocTestTask.Infrastructure.Configurations
{
    public class FounderConfiguration : IEntityTypeConfiguration<Founder>
    {
        public void Configure(EntityTypeBuilder<Founder> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.Surname)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.FatherName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.TaxpayerNumber)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .HasOne(p => p.Client)
                .WithMany(p => p.Founders)
                .HasForeignKey(p => p.ClientID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(p => p.TaxpayerNumber)
                .IsUnique();
        }
    }
}
