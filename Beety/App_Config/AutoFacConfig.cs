using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccess.EntitiesRepositories;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Beety.App_Config
{
    public class AutoFacConfig
    {
        private static IContainer container;

        public static IContainer GetIocContainer()
        {
            return container;
        }

        public static IServiceProvider ConfigureAutoFacContainer(IContainer applicationContainer, IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            RegisterTypes(builder);

            applicationContainer = builder.Build();

            container = applicationContainer;
            
            return new AutofacServiceProvider(applicationContainer);
        }

        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
