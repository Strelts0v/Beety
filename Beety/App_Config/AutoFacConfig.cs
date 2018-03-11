using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Beety.App_Config
{
    public class AutoFacConfig
    {
        private static IContainer _container;

        public static IContainer GetIocContainer()
        {
            return _container;
        }

        public static IServiceProvider ConfigureAutoFacContainer(IContainer applicationContainer, IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            RegisterTypes(builder);
            applicationContainer = builder.Build();
            _container = applicationContainer;
            
            return new AutofacServiceProvider(applicationContainer);
        }

        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<UsersService>().As<IUsersService>();
            builder.RegisterType<RolesService>().As<IRolesService>();
            builder.RegisterType<SecurityService>().As<ISecurityService>();
            builder.RegisterType<TokenStoreService>().As<ITokenStoreService>();
            builder.RegisterType<TokenValidatorService>().As<ITokenValidatorService>();
            builder.RegisterType<UserTokenRepository>().As<IUserTokenRepository>();
            builder.RegisterType<DbInitializerService>().As<IDbInitializerService>();
        }
    }
}
