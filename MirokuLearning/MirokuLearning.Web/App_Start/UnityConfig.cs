using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using System.Data.Entity;
using MirokuLearning.Business;
using MirokuLearning.Business.Core;
using AutoMapper;
using MirokuLearning.AppModel.Mapper;
using MirokuLearning.EF;
using MirokuLearning.EF.Repository;

namespace MirokuLearning.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, MirokuLearningContext>(new PerThreadLifetimeManager());
            container.RegisterType<IInstructionInOutRepository, InstructionInOutRepository>();
            container.RegisterType<ITransactionInOutRepository, TransactionInOutRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IItemRepository, ItemRepository>();
            container.RegisterType<IItemServices, ItemServices>();

            AutoMapperConfig.ConfigureAutoMapper();

            container.RegisterInstance<IMapper>(AutoMapperConfig.Mapper);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}