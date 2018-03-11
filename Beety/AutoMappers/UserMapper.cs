using AutoMapper;
using Models.Security;

namespace Beety.AutoMappers
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>().ForMember(x => x.Password, m => m.Ignore());
        }
    }
}
