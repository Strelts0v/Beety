using System.ComponentModel.DataAnnotations;

namespace Models.Entity
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
