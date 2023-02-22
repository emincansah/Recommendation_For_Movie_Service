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

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);

                addedEntity.State = EntityState.Added;

                context.SaveChanges();
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

        public async Task<List<TEntity>> GetAll(int pagecount)
        {
            using (TContext context = new TContext())
            { 
                return pagecount == 1 ? await context.Set<TEntity>().Take(100).ToListAsync() : await context.Set<TEntity>().Skip(pagecount*100).Take(100).ToListAsync();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);

                updatedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
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
