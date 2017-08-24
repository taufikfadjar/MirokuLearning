
using AutoMapper;
using MirokuLearning.AppModel.Views;
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
        Task<int> GetTotal(Expression<Func<Item, bool>> filter = null);
        Task CreateItem<Z>(Z itemViewModel);
        Task<Z> GetItem<Z>(Expression<Func<Item, bool>> filter = null);
    }

    public class ItemServices : IItemServices
    {
        private IItemRepository ItemRepository;
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public ItemServices(IItemRepository itemRepository, IUnitOfWork unitofWork, IMapper mapper )
        {
            ItemRepository = itemRepository;
            UnitOfWork = unitofWork;
            Mapper = mapper;
        }

        public async Task<List<Z>> GetItems<Z>(Expression<Func<Item, bool>> filter = null, 
            Expression<Func<Item,object>> orderingKey = null, int page = 0 , int pagesize = 0)
        {
            int total =  await ItemRepository.Count(filter);
            return await ItemRepository.GetListAsync<Z>(filter, orderingKey, total, page, pagesize);
        }

        public async Task<Z> GetItem<Z>(Expression<Func<Item, bool>> filter = null)
        {
            var item = await ItemRepository.GetAsync(filter);
            return Mapper.Map<Z>(item);
        }

        public async Task<int> GetTotal(Expression<Func<Item, bool>> filter = null)
        {
            int total = await ItemRepository.Count(filter);
            return total;
        }

        public async Task CreateItem<Z>(Z itemViewModel)
        {
            var item = Mapper.Map<Item>(itemViewModel);
            ItemRepository.Add(item);
            await UnitOfWork.AsyncSaveChange();
        }
    }
}
