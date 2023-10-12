﻿using MVC_Onion_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Domain.Core.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        Status Status { get; set; }


    }
}
