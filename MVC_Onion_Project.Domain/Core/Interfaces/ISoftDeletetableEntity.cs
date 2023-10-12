using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Core.Interfaces
{
    public interface ISoftDeletetableEntity: IEntity, ICreatetableEntity, IUpdatetableEntity
    {
        string? DeleteBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
