namespace TotemPWA.Models
{

    public class Promotion
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal Percent { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}