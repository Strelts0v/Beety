using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using GraphQL.Types;
using GraphQLModels.Types.SecurityTypes;
using Models.Security;

namespace Services.Queries.SecurityQueries
{
    public class UserQuery: ObjectGraphType
    {
        public UserQuery(IUserRepository userRepository)
        {
            Field<UserResultType>(
                "user",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<long>("id");
                    return userRepository.Get(x => x.Id == id, "Role").First();
                });

            Field<UsersResultType>(
                "users",
                resolve: ctx =>
                {
                    var users = userRepository.GetAll();
                    var usersDto = Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
                    return new Users() { UsersResult = usersDto };
                });
        }
    }
}
