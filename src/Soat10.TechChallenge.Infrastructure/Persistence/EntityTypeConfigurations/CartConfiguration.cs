using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<CartDao>
    {
        public void Configure(EntityTypeBuilder<CartDao> builder)
        {
            builder.ToTable("cart");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("cart_id");
            builder.Property(o => o.CustomerId).HasColumnName("customer_id");
            builder.Property(o => o.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasConversion(
                        v => v.ToString(),
                        v => (CartStatus)Enum.Parse(typeof(CartStatus), v));
            builder.Property(p => p.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();
            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .HasConstraintName("fk_cart_customer")
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(i => i.CartId)
                .HasConstraintName("fk_cart_item_cart")
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
