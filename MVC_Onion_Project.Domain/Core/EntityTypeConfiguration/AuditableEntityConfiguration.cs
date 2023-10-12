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
    public abstract class AuditableEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.DeleteBy).IsRequired(false); 
            builder.Property(x=> x.DeletedDate).IsRequired(false);
        }

    }
}
