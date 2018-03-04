using System;
using System.Collections.Generic;
using System.Text;
using Models.Security;
using Models.Security.Enums;

namespace Common.ValidationHelpers
{
    public class ValidationUserHelper
    {
        public static bool IsUserValid(User user)
        {
            if (user.Login == String.Empty) return false;
            if (user.EmailAddress == String.Empty ) return false;
            if (user.MobileNumber == String.Empty) return false;
            if (user.Password == String.Empty) return false;
            if (user.EmailAddress == String.Empty) return false;
            if (user.Role == null || (RoleType) user.Role.RoleType == RoleType.Admin) return false;
            return true;
        }
    }
}
