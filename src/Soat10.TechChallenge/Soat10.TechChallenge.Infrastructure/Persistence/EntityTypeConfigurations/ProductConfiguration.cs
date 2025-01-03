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
            builder.Property(o => o.Id).HasColumnName("product_id");
            builder.Property(p => p.Category).HasColumnName("category").IsRequired().HasMaxLength(255);
            builder.Property(p => p.Description).HasColumnName("description").IsRequired();
        }
    }
}
