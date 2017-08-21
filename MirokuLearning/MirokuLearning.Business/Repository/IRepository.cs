using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MirokuLearning.Business.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> enities);
        Task<bool> Any(Expression<Func<T, bool>> filter);
        Task<int> Count(Expression<Func<T, bool>> filter);
        T Get(Func<T, bool> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        List<T> GetList(Func<T, bool> filter);
        Task<List<T>> GetListAsync<TKey>(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, TKey>> orderingKey = null, int total = 0, int page = 0, int pageSize = 0);
        IQueryable<T> GetQueryable();
        void Remove(T entity);
        void Update(T entity);
    }
}