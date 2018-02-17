using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// Represents base class for data entity.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets or sets an unique entity identifier.
        /// </summary>
        [Key]
        public long Id { get; set; }
    }
}
