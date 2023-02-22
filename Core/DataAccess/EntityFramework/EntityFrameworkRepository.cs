using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EntityFrameworkRepository <TEntity, TContext> : IEntityRepository<TEntity>

        where TEntity : class, IEntity, new() 

        where TContext : DbContext, new()   

    {

        public async Task<bool> Add(TEntity entity)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var addedEntity = context.Entry(entity);

                    addedEntity.State = EntityState.Added;

                    context.SaveChanges();
                    return  true;
                }
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);

                deletedEntity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public async Task< TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            { 
                return filter == null ? await context.Set<TEntity>().ToListAsync() : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);

                updatedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
            return true;
        }
        public async Task<int> Count()
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().CountAsync();
            }
        }
      
    }
}
