using MVC_Onion_Project.Domain.Core.Interfaces;
using MVC_Onion_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Core.Base
{
    public abstract class BaseEntity : IUpdatetableEntity
    {
        public string? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
