using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.Business.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T: class
    {
        private DbSet<T> dbSet;
        private DbContext dbContext;

        public RepositoryBase(DbContext context)
        {
            dbSet = context.Set<T>();
            dbContext = context;
        }

        public IQueryable<T> GetQueryable()
        {
            return dbSet.AsQueryable();
        }

        public T Get(Func<T, bool> filter)
        {
           return dbSet.Where(filter).FirstOrDefault();
        }

        public List<T> GetList(Func<T, bool> filter)
        {
            return dbSet.Where(filter).ToList();
        }

        public async Task<int> Count(Expression<Func<T, bool>> filter)
        {
            return await dbSet.CountAsync(filter);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> filter)
        {
            return await dbSet.AnyAsync(filter);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.AsQueryable().Where(filter).ToListAsync();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> enities)
        {
            dbSet.AddRange(enities);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            if(dbContext.Entry<T>(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

       

    }
}
