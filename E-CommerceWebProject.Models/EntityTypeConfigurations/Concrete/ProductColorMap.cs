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
    public class ProductColorMap : BaseMap<ProductColor>
    {
        public override void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.Property(a => a.Color).HasMaxLength(30).IsRequired(true);
            builder.HasOne(a => a.Product).WithMany(a => a.ProductColors).HasForeignKey(a => a.ProductID);
            base.Configure(builder);
        }
    }
}
