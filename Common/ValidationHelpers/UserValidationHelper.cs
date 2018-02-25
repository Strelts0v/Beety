using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DataAccess;
using DataAccess.EntitiesRepositories;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using Models.Security;

namespace Common.ValidationHelpers
{
    public class UserValidationHelper
    {
        private readonly IUserRepository _userRepository;

        public UserValidationHelper(ApplicationDbContext dbContext)
        {
            _userRepository = new UserRepository(dbContext);
        }

        public void CreateUser(User user)
        {
            if (!IsUniqueLogin(user.Login))
            {
                user.Password = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
                _userRepository.Add(user);
                _userRepository.SaveChanges();
            }
        }

        public bool IsUniqueLogin(string login)
        {
            return _userRepository.GetAll().Any(u => u.Login == login);
        }

        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
