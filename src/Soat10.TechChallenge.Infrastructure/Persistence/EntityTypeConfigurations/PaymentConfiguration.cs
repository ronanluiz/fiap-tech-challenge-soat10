using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentDao>
    {
        public void Configure(EntityTypeBuilder<PaymentDao> builder)
        {
            builder.ToTable("payment");
            builder.HasKey(p => p.Id);
            builder.Property(o => o.Id)
                .HasColumnName("payment_id");
            builder.Property(p => p.OrderId)
                .HasColumnName("order_id");
            builder.Property(p => p.TotalAmount)
                .HasColumnName("total_amount")
                .HasColumnType("decimal(10, 2)")
                .IsRequired();
            builder.Property(p => p.Status).HasColumnName("status").HasDefaultValue("pending");
            builder.Property(p => p.DetailedStatus).HasColumnName("detailed_status").HasDefaultValue("pending");
            builder.Property(o => o.QrData).HasColumnName("qr_data");
            builder.Property(p => p.ExternalPaymentId)
                .HasColumnName("external_payment_id")
                .HasMaxLength(255)
                .IsRequired(false);
            builder.Property(p => p.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();
            builder.Property(p => p.PaidAt)
                   .HasColumnName("paid_at")
                   .IsRequired(false);

            builder.HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .HasConstraintName("fk_payment_order")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
