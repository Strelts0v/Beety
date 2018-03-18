using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Security;

namespace Services
{
    public interface IDbInitializerService
    {
        void Initialize();
        void SeedData();
    }

    public class DbInitializerService : IDbInitializerService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ISecurityService _securityService;

        public DbInitializerService(
            IServiceScopeFactory scopeFactory,
            ISecurityService securityService)
        {
            _scopeFactory = scopeFactory;
            _securityService = securityService;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    var allRoles = new List<Role>
                    {
                        new Role {Name = CustomRoles.Admin},
                        new Role {Name = CustomRoles.Moderator},
                        new Role {Name = CustomRoles.Organization},
                        new Role {Name = CustomRoles.Privator},
                        new Role {Name = CustomRoles.Client}
                    };

                    if (!context.Roles.Any())
                    {
                        context.AddRange(allRoles);
                        context.SaveChanges();
                    }

                    // Add Admin user
                    if (!context.Users.Any())
                    {
                        var adminUser = new User
                        {
                            Login = "admin",
                            EmailAddress = "dfvdvdfvdvdfvd@gmail.com",
                            MobileNumber = "13123123123",
                            IsActive = true,
                            Password = _securityService.GetSha256Hash("12345"),
                        };
                        context.Add(adminUser);
                        context.SaveChanges();

                        context.Add(new UserRole { Role = allRoles.SingleOrDefault(r => r.Name == CustomRoles.Admin), User = adminUser });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}