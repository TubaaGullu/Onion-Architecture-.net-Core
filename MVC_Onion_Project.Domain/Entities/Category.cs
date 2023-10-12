using MVC_Onion_Project.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CategoriesBooks> CategoriesBooks { get; set; }

    }
}
