using System.ComponentModel.DataAnnotations.Schema;
using static Models.Enums.Enums;

namespace Models.Security
{
    public class Privator : EntityBase
    {
        [ForeignKey("User")]
        public long UserId { get; set; }

        public User User { get; set; }

        public string PayerAccountNumber { get; set; }

        public ServiceCategory ServiceCategory { get; set; }

        public string Experience { get; set; }

        public ServiceSegment ServiceSegment { get; set; }
    }
}
