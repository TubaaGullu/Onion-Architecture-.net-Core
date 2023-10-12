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
    public class CategoriesBooksConfiguration : BaseEntityConfiguration<CategoriesBooks>
    {
        public override void Configure(EntityTypeBuilder<CategoriesBooks> builder)
        {
            base.Configure(builder);
        }
    }
}
