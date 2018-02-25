using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
