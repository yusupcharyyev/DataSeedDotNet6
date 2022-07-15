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
    public class CategoryMap: BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(20).IsRequired(true);
            builder.Property(a => a.Description).HasMaxLength(150).IsRequired(true);
            base.Configure(builder);
        }
    }
}
