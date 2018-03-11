using Models.Security;

namespace Common.ValidationHelpers
{
    public class ValidationUserHelper
    {
        public static bool IsUserValid(User user)
        {
            if (user.Login == string.Empty) return false;
            if (user.EmailAddress == string.Empty ) return false;
            if (user.MobileNumber == string.Empty) return false;
            if (user.Password == string.Empty) return false;
            if (user.EmailAddress == string.Empty) return false;
            return true;
        }
    }
}
