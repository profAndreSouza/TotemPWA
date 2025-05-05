namespace TotemPWA.Models
{

    public class Variation
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public decimal AdditionalPrice { get; set; }

        // 1-to-many relationship with products
        public int ProductId { get; set; }
        public required Product Product { get; set; }
    }
}
