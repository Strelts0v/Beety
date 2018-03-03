using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using Models.Security;

namespace GraphQLModels.Types.SecurityTypes
{
    public class Users
    {
        public IEnumerable<User> UsersResult { get; set; }
    }

    public class UsersResultType : ObjectGraphType 
    {
        public UsersResultType()
        {
            Field<ListGraphType<UserType>>("usersResult");
        }
    }
}
