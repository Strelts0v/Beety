using System.Collections.Generic;
using System.Linq;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using Models.Security;

namespace Services
{
    public interface IRolesService
    {
        IEnumerable<Role> FindUserRolesAsync(int userId);
        bool IsUserInRole(int userId, string roleName);
    }

    public class RolesService : IRolesService
    {
        private readonly IRoleRepository _roleRepository;

        public RolesService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IEnumerable<Role> FindUserRolesAsync(int userId)
        {
            var query = _roleRepository.FindUserRoles(userId);
            return query;
        }

        public bool IsUserInRole(int userId, string roleName)
        {
            var users = _roleRepository.FindUsersInRole(roleName);
            return users.Any(u => u.Id == userId);
        }
    }
}
