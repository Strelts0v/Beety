using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Security
{
    public class RegistrationToken: EntityBase
    {
        public string Token { get; set; }

        [Required]
        [ForeignKey("User")]
        public virtual User Client { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActivated { get; set; }

        public DateTime ActivationDate { get; set; }

        public bool IsCancelled { get; set; }

        public DateTime CancellationDate { get; set; }
    }
}
