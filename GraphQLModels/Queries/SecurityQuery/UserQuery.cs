using DataAccess.EntitiesRepositories;
using GraphQL.Types;
using GraphQLModels.Types.SecurityTypes;
using Models.Security;

namespace GraphQLModels.SecurityQuery
{
    public class UserQuery: ObjectGraphType
    {
        public UserQuery(IUserRepository userRepository)
        {
            Field<UserType>(
                "user",
                resolve: context => new User { Id = 10, FirstName = "R2-D2"}
            );

            Field<UserType>(
                "users",
                resolve: context => userRepository.GetAll()
            );
        }
    }
}
