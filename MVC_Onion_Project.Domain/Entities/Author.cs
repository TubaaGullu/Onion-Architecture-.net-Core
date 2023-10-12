using MVC_Onion_Project.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Entities
{
    public class Author : AuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
