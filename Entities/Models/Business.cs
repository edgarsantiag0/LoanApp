namespace Entities.Models
{
    public class Business
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }

        public int ZipCode { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string About { get; set; }

        public string LogoURL { get; set; }

        public string WebsiteURL { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

    }
}
