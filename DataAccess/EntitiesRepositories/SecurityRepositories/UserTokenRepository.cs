using Models.Security;

namespace DataAccess.EntitiesRepositories.SecurityRepositories
{
    public interface IUserTokenRepository : IRepository<UserToken>
    {
    }

    public class UserTokenRepository : RepositoryBase<UserToken>, IUserTokenRepository
    {
        public UserTokenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
