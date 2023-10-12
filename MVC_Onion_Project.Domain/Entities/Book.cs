using MVC_Onion_Project.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Entities
{
    public class Book : AuditableEntity
    {
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<CategoriesBooks> CategoriesBooks { get; set; }

     
    }
}
