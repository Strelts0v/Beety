using System;
using System.Security.Cryptography;
using System.Text;
using Models.Security;

namespace Common.ValidationHelpers
{
    public static class UserEncryptPasswordHelper
    {
        public static User CreateUser(User user)
        {
            user.Password = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return user;
        }

        private static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
