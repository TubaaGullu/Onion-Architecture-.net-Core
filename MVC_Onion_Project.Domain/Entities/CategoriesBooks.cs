using MVC_Onion_Project.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Entities
{
    public class CategoriesBooks : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; } 

    }
}
