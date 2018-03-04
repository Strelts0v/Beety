using AutoMapper;
using Beety.AutoMappers;
using Models.Security;

namespace Beety
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
                {
                    x.AddProfile<UserMapper>();
                });
        }
    }
}
