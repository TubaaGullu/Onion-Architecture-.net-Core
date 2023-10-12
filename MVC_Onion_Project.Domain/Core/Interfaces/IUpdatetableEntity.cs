using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Core.Interfaces
{
    public interface IUpdatetableEntity : IEntity, ICreatetableEntity
    {
        string? UpdateBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
