using AutoMapper;
using Beety.AutoMappers;

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
