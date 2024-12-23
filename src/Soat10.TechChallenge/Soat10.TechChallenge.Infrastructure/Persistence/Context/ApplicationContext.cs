using Microsoft.EntityFrameworkCore;
using Soat10.TechChallenge.Domain.Aggregates.CostumerAggregate;
using System.Transactions;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações específicas
        }
    }
}
