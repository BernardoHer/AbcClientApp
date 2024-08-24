using AbcClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AbcClientApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<ClientInfo> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientInfo>()
                .Property(c => c.EstimatedInsuranceValue)
                .HasColumnType("decimal(18,2)");
        }
    }
}
