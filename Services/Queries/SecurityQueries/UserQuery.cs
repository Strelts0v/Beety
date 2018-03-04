using System.Collections.Generic;
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
            Field<UserCreateDTOType>(
                "user",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserCreateDTOInputType>> { Name = "id" }
                ),
                resolve: context => userRepository.GetById(context.GetArgument<long>("id"))
            );

            Field<UsersResultType>(
                "users",
                resolve: ctx =>
                {
                    var users = userRepository.GetAll();
                    var usersDTO = Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
                    return new Users() { UsersResult = usersDTO };
                });
        }
    }
}
