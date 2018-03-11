namespace Models.Security
{
    public class UserDTO: EntityBase
    {
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public string Role { get; set; }
    }
}
