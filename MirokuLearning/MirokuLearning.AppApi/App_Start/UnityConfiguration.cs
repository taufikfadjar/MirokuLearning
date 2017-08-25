using AutoMapper;
using FluentValidation;
using FluentValidation.WebApi;
using Microsoft.Practices.Unity;
using MirokuLearning.AppModel.Mapper;
using MirokuLearning.AppModel.Validation;
using MirokuLearning.Business.Core;
using MirokuLearning.EF;
using MirokuLearning.EF.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MirokuLearning.AppApi.App_Start
{
    public class UnityConfiguration
    {
        public static IUnityContainer Config()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<DbContext, MirokuLearningContext>(new PerThreadLifetimeManager());
            container.RegisterType<IInstructionInOutRepository, InstructionInOutRepository>();
            container.RegisterType<ITransactionInOutRepository, TransactionInOutRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IItemRepository, ItemRepository>();
            container.RegisterType<IItemServices, ItemServices>();
            //container.RegisterType<IValidatorFactory, ModelValidatorFactory>();

            AutoMapperWebApiConfig.ConfigureAutoMapper();

            
        
            container.RegisterInstance<IMapper>(AutoMapperWebApiConfig.Mapper);

        return container;
        }
    }
}