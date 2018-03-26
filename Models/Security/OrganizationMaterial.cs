using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Security
{
    public class OrganizationMaterial: EntityBase
    {
        public string Name { get; set; }

        public decimal Value { get; set; }

        public int Count { get; set; }

        public long OrganizationId { get; set; }

        public Organization Organization { get; set; }
    }
}
