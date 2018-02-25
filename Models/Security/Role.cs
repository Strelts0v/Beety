using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Models.Enums.Enums;

namespace Models.Security
{
    public class Role: EntityBase
    {
        [StringLength(255)]
        public string RoleName { get; set; }

        public UserRole UserRole { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
