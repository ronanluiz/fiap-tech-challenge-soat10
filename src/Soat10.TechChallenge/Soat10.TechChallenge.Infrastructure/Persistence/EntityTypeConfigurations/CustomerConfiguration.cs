using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Domain.Entities;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");
            builder.HasKey(c => c.Id);
            builder.Property(o => o.Id).HasColumnName("customer_id");
            builder.Property(c => c.Name).HasColumnName("name").IsRequired().HasMaxLength(255);

            builder.OwnsOne(x => x.Cpf)
                    .Property(x => x.Number)
                    .HasColumnName("cpf")
                    .HasMaxLength(11);

            builder.OwnsOne(x => x.Email)
                    .Property(x => x.Address)
                    .HasColumnName("email")
                    .HasMaxLength(255);
        }
    }
}
