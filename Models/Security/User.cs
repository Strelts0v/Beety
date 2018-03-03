using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Security
{
    public class User: EntityBase
    {
        [StringLength(30)]
        [Required]
        public string Login { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string LastName { get; set; }

        public string PasswordSalt { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime? RegisteredAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int FailedLoginAttemptsCount { get; set; }

        [StringLength(255)]
        [Required]
        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }
    }
}
