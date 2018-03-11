using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Security
{
    public class Role : EntityBase
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
