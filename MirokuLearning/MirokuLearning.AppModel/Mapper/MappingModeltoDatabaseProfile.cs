using AutoMapper;
using MirokuLearning.AppModel.Extension;
using MirokuLearning.AppModel.Views;
using MirokuLearning.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.AppModel.Mapper
{
    public class MappingModeltoDatabaseProfile : Profile
    {
        public MappingModeltoDatabaseProfile()
        {
            CreateMap<ItemViewModel, Item>().IgnoreAllNonExisting();
        }
    }

    public class MappingAPIModeltoDatabaseProfile : Profile
    {
        public MappingAPIModeltoDatabaseProfile()
        {
            CreateMap<APIViewModels.ItemViewModel, Item>().IgnoreAllNonExisting();
        }
    }
}
