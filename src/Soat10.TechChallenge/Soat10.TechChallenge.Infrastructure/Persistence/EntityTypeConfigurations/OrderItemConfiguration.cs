using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Domain.Entities;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");
            builder.HasKey(oi => oi.Id);
            builder.Property(o => o.Id).HasColumnName("order_item_id");
            builder.Property(oi => oi.Quantity).HasColumnName("quantity").IsRequired();
            builder.Property(oi => oi.Price).HasColumnName("price").HasColumnType("decimal(10, 2)").IsRequired();
            builder.Property(oi => oi.Note).HasColumnName("note").HasMaxLength(255);

            builder.Property(o => o.OrderId).HasColumnName("order_id");
            builder.Property(o => o.ProductId).HasColumnName("product_id");

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId)
                .HasConstraintName("fk_order_item_order")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .HasConstraintName("fk_order_item_product")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
