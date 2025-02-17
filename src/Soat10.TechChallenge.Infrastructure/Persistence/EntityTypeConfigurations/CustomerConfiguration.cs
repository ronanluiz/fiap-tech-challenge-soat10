using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Application.Daos;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{

    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerDao>
    {
        public void Configure(EntityTypeBuilder<CustomerDao> builder)
        {
            builder.ToTable("customer");
            builder.HasKey(c => c.Id);
            builder.Property(o => o.Id).HasColumnName("customer_id");

            builder.Property(c => c.CreatedAt)
               .HasColumnName("created_at")
               .HasColumnType("timestamptz")
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

            builder.Property(x => x.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(11);

            builder.Property(c => c.Status)
               .HasColumnName("status")
               .HasDefaultValue("active")
               .HasMaxLength(30);


        }
    }
}
