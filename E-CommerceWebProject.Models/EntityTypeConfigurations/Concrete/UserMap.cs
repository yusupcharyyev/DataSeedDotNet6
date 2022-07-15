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
    public class UserMap : BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(a => a.FirstName).HasMaxLength(20).IsRequired(true);
            builder.Property(a => a.LastName).HasMaxLength(20).IsRequired(true);
            builder.Property(a => a.UserName).IsRequired(true);
            builder.Property(a => a.Password).IsRequired(true);
            builder.Property(a => a.IdentityId).IsRequired(true);
            builder.Property(a => a.BoutiqueName).IsRequired(true);
            builder.Property(a => a.Adres).HasMaxLength(300).IsRequired(true);

            base.Configure(builder);
        }
    }
}
