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
    public class CommentMap : BaseMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(a => a.Text).HasMaxLength(200).IsRequired(true);
            builder.HasKey(a => new { a.ProductID, a.UserID });
            base.Configure(builder);
        }
    }
}
