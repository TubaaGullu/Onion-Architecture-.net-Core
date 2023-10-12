using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Onion_Project.Domain.Core.EntityTypeConfiguration;
using MVC_Onion_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Infrastructure.Configurations
{
    public class AuthorConfiguration : AuditableEntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(65);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(65);
            builder.Property(x => x.DateofBirth).IsRequired();
            base.Configure(builder);
        }
    }
}
