using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Core.Interfaces
{
    public interface ICreatetableEntity : IEntity
    {
        string CreateBy { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
