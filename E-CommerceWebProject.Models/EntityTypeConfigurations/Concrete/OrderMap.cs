using E_CommerceWebProject.Models.Entities.Concrete;
using E_CommerceWebProject.Models.EntityTypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.EntityTypeConfigurations.Concrete
{
    public class OrderMap : BaseMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(a => a.TotalPrice).IsRequired(true);
            builder.HasOne(a => a.User).WithMany(a => a.Orders).HasForeignKey(a => a.CustomerID);
            base.Configure(builder);
        }
    }
}
