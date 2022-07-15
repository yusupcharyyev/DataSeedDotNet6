using E_CommerceWebProject.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.EntityTypeConfigurations.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.CreateDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(false);
            builder.Property(a => a.RemovedDate).IsRequired(false); 
            builder.Property(a => a.Statu).IsRequired(true);
        }
    }
}
