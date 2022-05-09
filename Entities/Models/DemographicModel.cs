using System.Collections.Generic;

namespace Entities.Models
{
    public class DemographicModel : Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Characteristics { get; set; }

        public ICollection<Customer> Customers { get; set; }

    }
}

//Demographic Characteristics

//Age.
//Gender.
//Race.
//Ethnicity.
//Geographic Area.
//Educational attainment.
//Income level.
