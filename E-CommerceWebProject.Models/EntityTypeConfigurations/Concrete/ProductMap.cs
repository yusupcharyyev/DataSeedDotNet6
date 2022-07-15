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
    public class ProductMap: BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(a => a.Code).HasMaxLength(25).IsRequired(true);
            builder.Property(a => a.Price).IsRequired(true);
            builder.Property(a => a.DiscountPrice).IsRequired(false);
            builder.Property(a => a.DiscountPercent).IsRequired(false);

            builder.HasOne(a=>a.User).WithMany(a=>a.Products).HasForeignKey(a=>a.UserID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            base.Configure(builder);   
        }
    }
}
