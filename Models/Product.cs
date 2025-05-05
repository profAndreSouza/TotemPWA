namespace TotemPWA.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }

        // 1-to-many relationship with categories
        public int CategoryId { get; set; }
        public required Category Category { get; set; }

        // 1-to-many relationship with variations
        public ICollection<Variation> Variations { get; set; } = new List<Variation>();
    }
}
