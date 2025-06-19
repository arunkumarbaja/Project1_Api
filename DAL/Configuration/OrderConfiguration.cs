using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne<ApplicationUser>() // Use shadow navigation
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.TotalAmount)
                   .HasColumnType("decimal(18, 2)");

            builder.HasMany(o => o.OrderItems)
                   .WithOne()
                   .HasForeignKey(oi => oi.OrderId);
        }
    }
}
