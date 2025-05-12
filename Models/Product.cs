using System.Text.Json.Serialization;

namespace TotemPWA.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        
        [JsonIgnore]
        public Category? Category { get; set; }
        public ICollection<Variation> Variations { get; set; } = new List<Variation>();
    }
}


