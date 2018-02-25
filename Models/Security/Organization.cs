using System.ComponentModel.DataAnnotations.Schema;
using static Models.Enums.Enums;

namespace Models.Security
{
    public class Organization : EntityBase
    {
        [ForeignKey("User")]
        public long UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public ServiceCategory ServiceCategory;

        public int? PersonalCount { get; set; }

        public ServiceSegment ServiceSegment { get; set; }
    }
}
