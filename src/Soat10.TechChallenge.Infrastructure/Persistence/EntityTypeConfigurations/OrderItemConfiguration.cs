using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItemDao>
    {
        public void Configure(EntityTypeBuilder<OrderItemDao> builder)
        {
            builder.ToTable("order_item");
            builder.HasKey(oi => oi.Id);
            builder.Property(o => o.Id).HasColumnName("order_item_id");
            builder.Property(oi => oi.Quantity).HasColumnName("quantity").IsRequired();
            builder.Property(oi => oi.Price).HasColumnName("price").HasColumnType("decimal(10, 2)").IsRequired();
            builder.Property(oi => oi.Note).HasColumnName("note").HasMaxLength(255);

            builder.Property(o => o.OrderId).HasColumnName("order_id");
            builder.Property(o => o.ProductId).HasColumnName("product_id");

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .HasConstraintName("fk_order_item_product")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
