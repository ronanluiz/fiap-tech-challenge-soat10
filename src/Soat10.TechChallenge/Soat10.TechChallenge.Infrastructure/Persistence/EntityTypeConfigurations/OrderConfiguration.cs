using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat10.TechChallenge.Domain.Entities;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order"); 
            builder.HasKey(o => o.Id).HasName("order_id");
            builder.Property(o => o.Status).HasColumnName("status").IsRequired().HasMaxLength(255);
            builder.Property(o => o.Amount).HasColumnName("amount").HasColumnType("decimal(10, 2)").IsRequired();
            builder.HasOne(o => o.Customer)
                .WithMany() 
                .HasForeignKey(o => o.CustomerId)
                .HasConstraintName("fk_order_customer")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
