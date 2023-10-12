using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Utilities.Interfaces
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
