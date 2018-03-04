using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using Models.Security;

namespace GraphQLModels.Types.SecurityTypes
{
    public class UserResultType : ObjectGraphType<User>
    {
        public UserResultType()
        {
            Name = "User";

            Field(x => x.Id, nullable: true).Description("The Id of the User.");
            Field(x => x.FirstName, nullable: true).Description("The FirstName of the User.");
            Field(x => x.LastName, nullable: true).Description("The LastName of the User.");
            Field(x => x.EmailAddress, nullable: true).Description("The Email of the User.");
            Field(x => x.Login, nullable: true).Description("The UserName of the User.");
            Field(x => x.MobileNumber, nullable: true).Description("The MobileNumber of the User.");
            Field("role", x => x.Role.RoleName, nullable: true).Description("The Role of the User.");
            Field(x => x.RegisteredAt, nullable: true).Description("The Date of the User was registered.");
        }
    }
}
