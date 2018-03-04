using GraphQL.Types;
using Models.Security;

namespace GraphQLModels.Types.SecurityTypes
{
    public class UserCreateDTOType: ObjectGraphType<UserDTO>
    {
        public UserCreateDTOType()
        {
            Name = "User";

            Field(x => x.Id).Description("The Id of the User.");
            Field(x => x.FirstName).Description("The FirstName of the User.");
            Field(x => x.LastName).Description("The LastName of the User.");
            Field(x => x.EmailAddress).Description("The Email of the User.");
            Field(x => x.Login).Description("The UserName of the User.");
            Field(x => x.Password).Description("The Password of the User.");
            Field(x => x.MobileNumber).Description("The MobileNumber of the User.");
            Field(x => x.Role).Description("The Role of the User.");
        }
    }
}
