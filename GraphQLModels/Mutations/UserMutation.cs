using System.Linq;
using Common.ValidationHelpers;
using DataAccess.EntitiesRepositories;
using GraphQL.Types;
using GraphQLModels.Types.SecurityTypes;
using Models.Security;

namespace GraphQLModels.Mutations
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(IUserRepository userRepository)
        {
            Name = "Mutation";

            Field<UserType>(
                "userCreate",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> {Name = "user" }
                ),
                resolve: context =>
                {
                    var user = UserEncryptPasswordHelper.CreateUser(context.GetArgument<User>("user"));
                    if (userRepository.GetAll().Any(u => u.Login == user.Login))
                    {
                        return null;
                    }

                    userRepository.Add(user);
                    userRepository.SaveChanges();
                    return user;
                });
        }
    }
}
