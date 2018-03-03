using System.Collections.Generic;
using System.Linq;
using Common.ValidationHelpers;
using DataAccess.EntitiesRepositories;
using GraphQL.Language.AST;
using GraphQL.Types;
using GraphQLModels.Types.SecurityTypes;
using GraphQLParser.AST;
using Models.Security;

namespace GraphQLModels.SecurityQuery
{
    public class UserQuery: ObjectGraphType
    {
        public UserQuery(IUserRepository userRepository)
        {
            Field<UserType>(
                "user",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "id" }
                ),
                resolve: context => userRepository.GetById(context.GetArgument<long>("id"))
            );

            Field<UsersResultType>(
                "users",
                resolve: ctx => new Users(){ UsersResult = userRepository.GetAll()});
        }
    }
}
