using Jobber.IO.Business.Interfaces;
using Jobber.IO.Business.Models;
using Jobber.IO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jobber.IO.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly JobberDbContext jobberDbContext;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(JobberDbContext db)
        {
            jobberDbContext = db;
            dbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }
        public virtual async Task Add(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }
        public virtual async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }                     

        public async Task<int> SaveChanges()
        {
            return await jobberDbContext.SaveChangesAsync();
        }
     
        public void Dispose()
        {
            jobberDbContext?.Dispose();
        }
    }
}
