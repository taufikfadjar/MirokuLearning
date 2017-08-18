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
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> GetQueryable();
        void Remove(T entity);
        void Update(T entity);
    }
}