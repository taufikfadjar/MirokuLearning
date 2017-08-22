
using MirokuLearning.EF;
using MirokuLearning.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.Business.Core
{
    public interface IItemServices
    {
        Task<List<Z>> GetItems<Z>(Expression<Func<Item, bool>> filter = null,
            Expression<Func<Item, object>> orderingKey = null, int page = 0, int pagesize = 0);
    }

    public class ItemServices : IItemServices
    {
        private IItemRepository ItemRepository;
        private IUnitOfWork UnitOfWork;

        public ItemServices(IItemRepository itemRepository, IUnitOfWork unitofWork )
        {
            ItemRepository = itemRepository;
            UnitOfWork = unitofWork;
        }

        public async Task<List<Z>> GetItems<Z>(Expression<Func<Item, bool>> filter = null, 
            Expression<Func<Item,object>> orderingKey = null, int page = 0 , int pagesize = 0)
        {
            int total =  await ItemRepository.Count(filter);
            return await ItemRepository.GetListAsync<Z>(filter, orderingKey, total, page, pagesize);
        }
    }
}
