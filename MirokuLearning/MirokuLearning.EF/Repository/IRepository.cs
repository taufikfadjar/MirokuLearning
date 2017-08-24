using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.EF.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> enities);
        Task<bool> Any(Expression<Func<T, bool>> filter);
        Task<int> Count(Expression<Func<T, bool>> filter = null);
        T Get(Func<T, bool> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        List<T> GetList(Func<T, bool> filter);
        Task<List<Z>> GetListAsync<Z>(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderingKey = null, int total = 0, int page = 0, int pageSize = 0);
        Task<List<object>> GetListAsync<Z>(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderingKey = null, List<string> lstFields = null, int total = 0, int page = 0, int pageSize = 0);
        IQueryable<T> GetQueryable();
        void Remove(T entity);
        void Update(T entity);
    }
}
