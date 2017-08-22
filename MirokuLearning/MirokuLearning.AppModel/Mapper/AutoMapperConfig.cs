using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.AppModel.Mapper
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper;
        public static void ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingModelToDatabaseProfile>();

            });

            Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }
}
