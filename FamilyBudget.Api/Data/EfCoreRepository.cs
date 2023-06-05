using FamilyBudget.Api.Model;
using FamilyBudget.Data;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudget.Api.Data
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext context;
        protected const int MAX_PAGE_SIZE = 50;

        public EfCoreRepository(TContext context)
        {
            this.context = context;
        }
        public virtual async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll(int pageNumber = 0, int pageSize = 0)
        {
            if (pageNumber > 0 && pageSize > 0)
            {
                pageSize = (pageSize > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : pageSize;
                int count = await context.Set<TEntity>().CountAsync();
                return await context.Set<TEntity>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
