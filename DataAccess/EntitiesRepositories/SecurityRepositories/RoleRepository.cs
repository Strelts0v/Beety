using System;
using System.Collections.Generic;
using System.Text;
using Models.Security;

namespace DataAccess.EntitiesRepositories.SecurityRepositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
