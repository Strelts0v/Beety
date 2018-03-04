using System.Linq;
using AutoMapper;
using Common.ValidationHelpers;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using GraphQL.Types;
using GraphQLModels.Types.SecurityTypes;
using Microsoft.AspNetCore.Routing.Tree;
using Models.Security;

namespace Services.Commands.Mutations.SecurityMutations
{
    public class UserCreateMutation : ObjectGraphType
    {
        public UserCreateMutation(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            Name = "UserCreate";

            Field<UserCreateDTOType>(
                "userCreate",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserCreateDTOInputType>> {Name = "user" }
                ),
                resolve: context =>
                {
                    var userDto = context.GetArgument<UserDTO>("user");
                    var user = Mapper.Map<User>(userDto);
                    user.Role = roleRepository.Get(x => x.RoleType == userDto.Role).First();

                    if (!ValidationUserHelper.IsUserValid(user)) return null;
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