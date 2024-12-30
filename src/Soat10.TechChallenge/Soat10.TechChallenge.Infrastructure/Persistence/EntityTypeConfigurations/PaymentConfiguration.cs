using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Domain.Entities;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payment");
            builder.HasKey(p => p.Id).HasName("payment_id");
            builder.Property(p => p.Id).HasColumnName("payment_id").HasMaxLength(255).IsRequired(); // Configura a coluna payment_id
            builder.Property(p => p.Amount).HasColumnName("amount").HasColumnType("decimal(10, 2)").IsRequired();

            builder.HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .HasConstraintName("fk_payment_order")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
