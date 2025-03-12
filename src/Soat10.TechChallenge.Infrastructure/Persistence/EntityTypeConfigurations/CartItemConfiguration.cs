using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItemDao>
    {
        public void Configure(EntityTypeBuilder<CartItemDao> builder)
        {
            builder.ToTable("cart_item");
            builder.HasKey(oi => oi.Id);
            builder.Property(o => o.Id).HasColumnName("cart_item_id");
            builder.Property(oi => oi.Quantity).HasColumnName("quantity").IsRequired();
            builder.Property(oi => oi.Notes).HasColumnName("notes").HasMaxLength(255);

            builder.Property(o => o.CartId).HasColumnName("cart_id");
            builder.Property(o => o.ProductId).HasColumnName("product_id");

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .HasConstraintName("fk_cart_item_product")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
