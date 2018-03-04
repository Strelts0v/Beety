using AutoMapper;
using Models.Security;

namespace Beety.AutoMappers
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<UserDTO, User>()
                .ForMember(x => x.Role, m => m.Ignore());

            CreateMap<User, UserDTO>().ForMember(x => x.Password, m => m.Ignore());
        }
    }
}
