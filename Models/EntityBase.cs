using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
