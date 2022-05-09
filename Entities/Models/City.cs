using System.Collections.Generic;

namespace Entities.Models
{
    public class City : Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StateId { get; set; }

        public State State { get; set; }

        public ICollection<Customer> Customers { get; set; }

    }
}
