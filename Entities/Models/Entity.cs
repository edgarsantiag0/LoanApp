using System;

namespace Entities.Models
{
    public class Entity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime Created { get; set; } = new DateTime();
        public DateTime Modified { get; set; } = new DateTime();
    }
}
