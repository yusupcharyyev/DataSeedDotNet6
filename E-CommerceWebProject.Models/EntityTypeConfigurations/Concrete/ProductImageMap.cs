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
    public class ProductImageMap : BaseMap<ProductImage>
    {
        public override void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.Property(a => a.Image).HasMaxLength(300).IsRequired(true);
            builder.HasOne(a => a.ProductColor).WithMany(a => a.ProductImages).HasForeignKey(a => a.ProductColorID);
            base.Configure(builder);
        }
    }
}
