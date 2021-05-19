using System.ComponentModel.DataAnnotations;

namespace Project_Work
{
    class Supermarket
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string House_Number { get; set; }
        public string AddressString { get; set; }
        public Supermarket()
        {

        }
        public Supermarket(string name, string country, string city, string street, string housenumber)
        {
            this.Name = name;
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.House_Number = housenumber;

            this.AddressString = City + ", " + Country + ". Ул. " + Street + ", " + House_Number;
        }

    }
}