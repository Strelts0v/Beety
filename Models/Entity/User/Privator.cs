using static Common.Enums.Enums;

namespace Models.Entity.User
{ 
    public class Privator : User
    {
        public string PayerAccountNumber { get; set; }

        public ServiceCategory ServiceCategory { get; set; }

        public string Experience { get; set; }

        public ServiceSegment ServiceSegment { get; set; }
    }
}
