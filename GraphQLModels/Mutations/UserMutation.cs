using Common.ValidationHelpers;
using GraphQL.Types;
using GraphQLModels.Types.SecurityTypes;
using Models.Security;

namespace GraphQLModels.Mutations
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(UserValidationHelper userValidationHelper)
        {
            Name = "Mutation";

            Field<UserType>(
                "userCreate",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> {Name = "user" }
                ),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    userValidationHelper.CreateUser(user);
                    return user;
                });
        }
    }
}
