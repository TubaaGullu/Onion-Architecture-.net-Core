using MVC_Onion_Project.Domain.Core.Interfaces;
using MVC_Onion_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Core.Base
{
    public abstract class AuditableEntity :BaseEntity, ISoftDeletetableEntity
    {
        public string? DeleteBy { get; set; }
        public DateTime? DeletedDate { get; set; }
     
    }
}
