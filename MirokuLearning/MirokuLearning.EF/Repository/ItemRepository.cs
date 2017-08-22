using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.EF.Repository
{
    public interface IItemRepository : IRepository<Item>
    {

    }

    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
