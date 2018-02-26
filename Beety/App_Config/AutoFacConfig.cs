using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccess.EntitiesRepositories;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Beety.App_Config
{
    public class AutoFacConfig
    {
        public static IServiceProvider ConfigureAutoFac(IContainer applicationContainer, IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            RegisterTypes(builder);

            applicationContainer = builder.Build();
           
            return new AutofacServiceProvider(applicationContainer);
        }

        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
