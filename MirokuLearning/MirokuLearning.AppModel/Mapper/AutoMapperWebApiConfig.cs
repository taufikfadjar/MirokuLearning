using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.AppModel.Mapper
{
    public class AutoMapperWebApiConfig
    {
        public static IMapper Mapper;
        public static void ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingAPIModelToDatabaseProfile>();
                cfg.AddProfile<MappingAPIModeltoDatabaseProfile>();
            });

            Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }
}
