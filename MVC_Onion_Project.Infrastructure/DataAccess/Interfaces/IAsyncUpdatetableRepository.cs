using MVC_Onion_Project.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Infrastructure.DataAccess.Interfaces
{
    public interface IAsyncUpdatetableRepository <TEntity>: IAsyncRepository where TEntity : BaseEntity
    {
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
