using AutoMapper;
using MirokuLearning.AppModel.Views;
using MirokuLearning.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.AppModel.Mapper
{
    public class MappingModelToDatabaseProfile : Profile
    {
        public MappingModelToDatabaseProfile()
        {
            CreateMap<Item, ItemViewModel>();
        }
    }
 }
