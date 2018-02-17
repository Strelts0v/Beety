using static Common.Enums.Enums;

namespace Models.Entity.User
{
    public class Organization : User
    {
        public string ChiefName { get; set; }

        public ServiceCategory ServiceCategory;

        public int? PersonalCount { get; set; }

        public ServiceSegment ServiceSegment { get; set; }
    }
}
