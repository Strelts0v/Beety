using static Common.Enums.Enums;

namespace Models.Entity.User
{
    public class Redactor : BaseUser
    {
        public UserRole UserRole { get; set; }//Administrator or Moderator
    }
}
