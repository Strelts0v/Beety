using AutoMapper;
using Models.Security;

namespace Beety.AutoMappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDTO, User>()
               .ForMember(x => x.UserRoles, m => m.Ignore())
               .ForMember(x => x.UserTokens, m => m.Ignore());

            CreateMap<User, UserDTO>().ForMember(x => x.Password, m => m.Ignore());
        }
    }
}
