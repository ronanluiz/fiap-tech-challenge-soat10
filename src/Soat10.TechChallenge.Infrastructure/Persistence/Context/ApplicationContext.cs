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
        public DbSet<OrderProductDao> OrderProducts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProductDao>(entity =>
            {
                entity.ToView("vw_order_products").HasNoKey();
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.Products).HasColumnName("products");
            });

            // Configurações das entidades (ver detalhes abaixo)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
