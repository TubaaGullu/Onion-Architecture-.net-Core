using MVC_Onion_Project.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Infrastructure.DataAccess.Interfaces
{
    public interface IAsyncInserttableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
    }
}
