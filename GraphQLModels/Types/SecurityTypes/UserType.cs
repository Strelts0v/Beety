using GraphQL.Types;
using Models.Security;

namespace GraphQLModels.Types.SecurityTypes
{
    public class UserType: ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";

            Field(x => x.Id).Description("The Id of the User.");
            Field(x => x.FirstName).Description("The FirstName of the User.");
            Field(x => x.LastName).Description("The LastName of the User.");
            Field(x => x.EmailAddress).Description("The Email of the User.");
            Field(x => x.Login).Description("The UserName of the User.");
            Field(x => x.Password).Description("The Password of the User.");
        }
    }
}
