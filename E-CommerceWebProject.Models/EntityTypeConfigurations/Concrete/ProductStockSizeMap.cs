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
    public class ProductStockSizeMap : BaseMap<ProductStockSize>
    {
        public override void Configure(EntityTypeBuilder<ProductStockSize> builder)
        {
            builder.Property(a => a.Stock).IsRequired(true);
            builder.Property(a => a.BodySize).HasMaxLength(5).IsRequired(true);

            builder.HasOne(a => a.ProductColor).WithMany(a => a.ProductStockSizes).HasForeignKey(a => a.ProductColorID);
            base.Configure(builder);
        }
    }
}
