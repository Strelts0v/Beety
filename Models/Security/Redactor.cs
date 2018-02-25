using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Models.Enums.Enums;

namespace Models.Security
{
    public class Redactor : EntityBase
    {
        [ForeignKey("User")]
        public long UserId { get; set; }

        public User User { get; set; }

        public UserRole UserRole { get; set; }//Administrator or Moderator
    }
}
