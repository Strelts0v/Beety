using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models.Security;

namespace DataAccess.EntitiesRepositories.SecurityRepositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        List<User> FindUsersInRole(string roleName);
        List<Role> FindUserRoles(int userId);
        void AddUserRole(User user, Role role);
    }

    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        protected ApplicationDbContext dbContext { get; }

        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            dbContext = context;
        }

        public List<User> FindUsersInRole(string roleName)
        {
            var role = dbContext.Roles.Where(r => r.Name == roleName).Include(r => r.UserRoles)
                .ThenInclude(ur => ur.User).ToList();
            var users = role.SingleOrDefault()?.UserRoles.Select(ur => ur.User).ToList();
            return users;
        }

        public List<Role> FindUserRoles(int userId)
        {
            var roles = new List<Role>();
            var userRoles = dbContext.UserRoles.Include(ur => ur.Role)
                .Where(ur => ur.UserId == userId).ToList();
            userRoles.ForEach(userRole => { roles.Add(userRole.Role); });
            return roles;
        }

        public void AddUserRole(User user, Role role)
        {
            dbContext.Add(new UserRole { Role = role, User = user });
            dbContext.SaveChanges();
        }
    }
}
