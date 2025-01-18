using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Domain.Entities;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("product_id");

            builder.Property(p => p.Name)
                   .HasColumnName("name")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Description)
                   .HasColumnName("description")
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.ProductCategory)
                   .HasColumnName("category")
                   .IsRequired();

            builder.Property(p => p.Price)
                   .HasColumnName("price")
                   .IsRequired()
                   .HasPrecision(10, 2); // Define precisão para valores monetários

            builder.Property(p => p.Status)
                   .HasColumnName("status")
                   .IsRequired();

            builder.Property(p => p.TimeToPrepare)
                   .HasColumnName("time_to_prepare")
                   .IsRequired();

            builder.Property(p => p.Note)
                   .HasColumnName("note")
                   .HasMaxLength(255); // Nota é opcional, mas limitamos o tamanho máximo

            builder.Property(p => p.IsAvailable)
                   .HasColumnName("is_available")
                   .IsRequired();

            builder.Property(p => p.CreatedAt)
                 .HasColumnName("created_at")
                 .IsRequired();

            builder.Property(p => p.UpdatedAt)
                   .HasColumnName("updated_at")
                   .IsRequired();

            builder.Property(p => p.UserUpdated)
                   .HasColumnName("user_updated")
                   .HasMaxLength(100);
        }
    }
}
