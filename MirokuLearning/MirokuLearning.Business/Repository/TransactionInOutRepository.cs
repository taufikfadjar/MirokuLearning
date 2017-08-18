using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.Business.Repository
{
    public interface ITransactionInOutRepository : IRepository<TransactionInOut>
    {

    }

    public class TransactionInOutRepository : RepositoryBase<TransactionInOut>, ITransactionInOutRepository
    {
        public TransactionInOutRepository(DbContext context) : base(context)
        {

        }
    }
}
