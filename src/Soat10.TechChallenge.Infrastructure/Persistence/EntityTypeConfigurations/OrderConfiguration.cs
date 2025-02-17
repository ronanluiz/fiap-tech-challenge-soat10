using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Application.Daos;
using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderDao>
    {
        public void Configure(EntityTypeBuilder<OrderDao> builder)
        {
            builder.ToTable("order");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("order_id");
            builder.Property(o => o.CustomerId).HasColumnName("customer_id");
            builder.Property(o => o.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasConversion(
                        v => v.ToString(),
                        v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));
            builder.Property(o => o.Amount).HasColumnName("amount").HasColumnType("decimal(10, 2)").IsRequired();
            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .HasConstraintName("fk_order_customer")
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(i => i.OrderId)
                .HasConstraintName("fk_order_item_order")
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
