using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.EF.Repository
{
    public class RepositoryBase<T> where T : class
    {
        private DbSet<T> dbSet;
        private DbContext dbContext;
        private IMapper Mapper;

        public RepositoryBase(DbContext context, IMapper mapper)
        {
            dbSet = context.Set<T>();
            dbContext = context;
            Mapper = mapper;
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

        public async Task<int> Count(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await dbSet.CountAsync(filter);
            }
            else
            {
                return await dbSet.CountAsync();
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> filter)
        {
            return await dbSet.AnyAsync(filter);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<List<Z>> GetListAsync<Z>(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderingKey = null, int total = 0, int page = 0, int pageSize = 0)
        {
            var query = dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderingKey != null)
            {
                query = query.OrderBy(orderingKey);
            }

            var skip = pageSize * (page - 1);
            var canPage = skip < total;

            if (canPage)
            {
                query = query.Skip(skip);
                query = query.Take(pageSize);

                return await query.ProjectTo<Z>(Mapper.ConfigurationProvider).ToListAsync();
            }
            else
            {
                return new List<Z>();
            }
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
            if (dbContext.Entry<T>(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}
