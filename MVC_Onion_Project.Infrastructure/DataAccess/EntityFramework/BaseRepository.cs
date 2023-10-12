using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MVC_Onion_Project.Domain.Core.Base;
using MVC_Onion_Project.Infrastructure.AppContext;
using MVC_Onion_Project.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Infrastructure.DataAccess.EntityFramework
{
    public abstract class BaseRepository<TEntity> : IAsyncOrderableRepository<TEntity>,
        IAsyncRepository, IAsyncDeletetableRepository<TEntity>, IAsyncInserttableRepository<TEntity>,
        IAsyncQueryableRepository<TEntity>, IRepository, IAsyncFindableRepository<TEntity>, 
        IAsyncUpdatetableRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _table;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity) 
        {
           var entry= await _table.AddAsync(entity);
            return entry.Entity;
            
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return _table.AddRangeAsync(entities);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return  expression is null? GetAllActives().AnyAsync(): GetAllActives().AnyAsync(expression);
            
        }

        public Task DeleteAsync(TEntity entity)
        {
            return Task.FromResult( _table.Remove(entity));
        }

        public  Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {

            _table.RemoveRange(entities);
           return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> orderby, bool orderDesc, bool tracking = true)
        {
            return orderDesc ? await GetAllActives(tracking).OrderByDescending(orderby).ToListAsync() : await GetAllActives(tracking).OrderBy(orderby).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TKey>> orderby, bool orderDesc = false, bool tracking = true)
        {
            var values = GetAllActives(tracking).Where(expression);
            return orderDesc ? await values.OrderByDescending(orderby).ToListAsync() : await values.OrderBy(orderby).ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true)
        {
            return await GetAllActives(tracking).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return await GetAllActives(tracking).Where(expression).ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracing = true)
        {
            return await GetAllActives(tracing).FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, bool tracing = true)
        {
            return await GetAllActives(tracing).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TEntity?>> GetByIdsAsync(List<Guid> ids, bool tracing = true)
        {
            var result = await GetAllActives(tracing).Where(x => ids.Contains(x.Id)).ToListAsync();
            return result;
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry= await Task.FromResult(_table.Update(entity));
            return  entry.Entity;
        }


        protected IQueryable<TEntity> GetAllActives(bool tracking=true)
        { 
            var values= _table.Where(x=>x.Status!= Domain.Enums.Status.Deleted);
            return tracking? values: values.AsNoTracking();
        }
    }
}
