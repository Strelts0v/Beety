using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Beety.App_Config;
using DataAccess;
using DataAccess.EntitiesRepositories;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using GraphQLModels.Mutations;
using GraphQLModels.SecurityQuery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Beety
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // IContainer instance in the Startup class 
        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));
            
            services.AddMvc();

            var container = AutoFacConfig.ConfigureAutoFacContainer(ApplicationContainer, services);
            services.AddTransient<UserMutation>();
            return container;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
        }
    }
}
