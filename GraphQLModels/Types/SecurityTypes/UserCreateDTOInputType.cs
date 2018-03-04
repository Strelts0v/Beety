using GraphQL.Types;

namespace GraphQLModels.Types.SecurityTypes
{
    public class UserCreateDTOInputType : InputObjectGraphType
    {
        public UserCreateDTOInputType()
        {
            Name = "UserInput";
            Field<NonNullGraphType<StringGraphType>>("login");
            Field<NonNullGraphType<StringGraphType>>("password");
            Field<NonNullGraphType<StringGraphType>>("emailAddress");
            Field<NonNullGraphType<StringGraphType>>("mobileNumber");
            Field<NonNullGraphType<StringGraphType>>("role");
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
        }
    }
}
