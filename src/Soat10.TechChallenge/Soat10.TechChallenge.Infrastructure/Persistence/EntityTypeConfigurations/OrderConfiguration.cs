using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
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
        }
    }
}
