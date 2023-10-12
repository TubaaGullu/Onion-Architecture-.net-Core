using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Onion_Project.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Core.EntityTypeConfiguration
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); // değer üretiyor.
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreateBy).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdateBy).IsRequired(false);
            builder.Property(x => x.UpdatedDate).IsRequired(false);


        }
    }
}
