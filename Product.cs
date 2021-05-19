using System.ComponentModel.DataAnnotations;

namespace Project_Work
{
    class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Measure { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string DSTU { get; set; }
        [Required]
        public int ManufactureId { get; set; }
        public Manufacture Manufacture { get; set; }
        public string ManufactureName { get; set; }
        [Required]
        public int SupermarketId { get; set; }
        public Supermarket Supermarket { get; set; }
        public string SupermarketName { get; set; }
        public Product()
        {

        }
        public Product(string name, int amount, string measure, double price, string dstu, Manufacture manufacture, Supermarket supermarket)
        {
            this.Name = name;
            this.Amount = amount;
            this.Measure = measure;
            this.Price = price;
            this.DSTU = dstu;
            Manufacture = manufacture;
            Supermarket = supermarket;
            ManufactureName = manufacture.Name;
            SupermarketName = supermarket.Name;
        }
    }
}