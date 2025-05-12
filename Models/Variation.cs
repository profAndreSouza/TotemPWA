using System.Text.Json.Serialization;

namespace TotemPWA.Models
{

    public class Variation
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public decimal AdditionalPrice { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
