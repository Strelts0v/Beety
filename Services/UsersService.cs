using System.Linq;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using Models.Security;

namespace Services
{
    public interface IUsersService
    {
        User FindUser(string login, string password);
        User FindUser(int userId);
    }

    public class UsersService : IUsersService
    {
        private readonly ISecurityService _securityService;
        private readonly IUserRepository _userRepository;

        public UsersService(ISecurityService securityService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }

        public User FindUser(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public User FindUser(string login, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            return _userRepository.Get(u => u.Login == login && u.Password == passwordHash).FirstOrDefault();
        }
    }
}
