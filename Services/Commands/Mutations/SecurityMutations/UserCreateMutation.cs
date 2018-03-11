using System.Linq;
using AutoMapper;
using Common.ValidationHelpers;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using GraphQL.Types;
using GraphQLModels.Types.SecurityTypes;
using Models.Security;

namespace Services.Commands.Mutations.SecurityMutations
{
    public class UserCreateMutation : ObjectGraphType
    {
        public UserCreateMutation(IUserRepository userRepository, IRoleRepository roleRepository, ISecurityService securityService)
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

                    if (!ValidationUserHelper.IsUserValid(user)) return null;
                    if (userRepository.GetAll().Any(u => u.Login == user.Login))
                    {
                        return null;
                    }

                    user.Password = securityService.GetSha256Hash(user.Password);
                    var role = roleRepository.Get(x => x.Name == userDto.Role).SingleOrDefault();

                    userRepository.Add(user);
                    userRepository.SaveChanges();
                    roleRepository.AddUserRole(user, role);
                    roleRepository.SaveChanges();
                    return user;
                });
        }
    }
}