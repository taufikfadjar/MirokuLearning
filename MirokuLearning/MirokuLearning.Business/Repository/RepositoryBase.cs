using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.Business.Repository
{
    public class RepositoryBase<T> where T: class
    {
        private DbSet<T> dbSet;

        public RepositoryBase(DbContext context)
        {
            dbSet = context.Set<T>();
        }

        public IQueryable<T> GetQueryable()
        {
            return dbSet.AsQueryable();
        }



    }
}
