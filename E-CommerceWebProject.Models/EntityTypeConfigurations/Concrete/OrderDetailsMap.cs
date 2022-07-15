using E_CommerceWebProject.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.EntityTypeConfigurations.Concrete
{
    public class OrderDetailsMap : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.Property(a => a.Price).IsRequired(true);
            builder.Property(a => a.Stock).IsRequired(true);
            builder.Property(a => a.DiscountPercent).IsRequired(false);
            builder.Property(a => a.DiscountPrice).IsRequired(false);

            builder.HasKey(a => new { a.OrderID, a.ProductID });
        }
    }
}
