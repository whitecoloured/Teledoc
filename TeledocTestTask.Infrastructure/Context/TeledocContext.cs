using Microsoft.EntityFrameworkCore;
using TeledocTestTask.Domain.Models;
using TeledocTestTask.Infrastructure.Configurations;

namespace TeledocTestTask.Infrastructure.Context
{
    public class TeledocContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }

        public TeledocContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new FounderConfiguration());
        }
    }
}
