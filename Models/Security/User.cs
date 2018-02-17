using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Common.Enums.Enums;

namespace Models.Security
{
    public class User: EntityBase
    {
        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string LastName { get; set; }

        public string PasswordSalt { get; set; }

        public string Password { get; set; }


        public UserRole? UserRole { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDay { get; set; }

        public string Photo { get; set; }

        public string BossName { get; set; }

        public ServiceCategory? ServiceCategory;

        public int? PersonalCount { get; set; }

        public ServiceSegment? ServiceSegment { get; set; }

        public string PayerAccountNumber { get; set; }

        public string Experience { get; set; }


        [Required]
        public virtual RegistrationToken Token { get; set; }

        public DateTime? RegisteredAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int FailedLoginAttemptsCount { get; set; }

        [StringLength(255)]
        public string EmailAddress { get; set; }
    }
}
