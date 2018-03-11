using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Security
{
    public class User: EntityBase
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
        }

        [StringLength(30)]
        [Required]
        public string Login { get; set; }

        [StringLength(255)]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string LastName { get; set; }

        public DateTime? RegisteredAt { get; set; }

        public int FailedLoginAttemptsCount { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }
    }
}
