using MirokuLearning.Business.Repository;
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
        Task<List<Item>> GetItems<TKey>(Expression<Func<Item, bool>> filter, Expression<Func<Item, TKey>> orderingKey, int page, int pagesize);
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

        public async Task<List<Item>> GetItems<TKey>(Expression<Func<Item, bool>> filter, Expression<Func<Item, TKey>> orderingKey, int page, int pagesize)
        {
            int total =  await ItemRepository.Count(filter);
            return await ItemRepository.GetListAsync(filter, orderingKey, total, page, pagesize);
        }
    }
}
