using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Application.Daos;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentDao>
    {
        public void Configure(EntityTypeBuilder<PaymentDao> builder)
        {
            builder.ToTable("payment");
            builder.HasKey(p => p.Id);
            builder.Property(o => o.Id).HasColumnName("payment_id");
            builder.Property(p => p.OrderId).HasColumnName("order_id");
            builder.Property(p => p.Amount).HasColumnName("amount").HasColumnType("decimal(10, 2)").IsRequired();

            builder.HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .HasConstraintName("fk_payment_order")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
