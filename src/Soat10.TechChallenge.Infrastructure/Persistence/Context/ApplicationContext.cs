using Microsoft.EntityFrameworkCore;
using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CustomerDao> Customers { get; set; }
        public DbSet<OrderDao> Orders { get; set; }
        public DbSet<PaymentDao> Payments { get; set; }
        public DbSet<ProductDao> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
