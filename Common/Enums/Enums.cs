using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Enums
{
    public abstract class Enums
    {
        public enum ServiceCategory : int
        {
            Barbershop = 1
        };

        public enum ServiceSegment : int
        {
            Econom = 1,
            Medium = 2,
            Premium = 3
        };

        public enum UserRole : int
        {
            Client = 1,
            Privator = 2,
            Organization = 3,
            Administrator = 4,
            Moderator = 5
        };
    }
}
