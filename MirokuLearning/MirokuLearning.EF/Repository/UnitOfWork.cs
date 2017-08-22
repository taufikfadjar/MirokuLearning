using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.EF.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

        private DbContext dbContext;

        public UnitOfWork(DbContext context)
        {
            dbContext = context;
        }

        public async Task<int> AsyncSaveChange()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
