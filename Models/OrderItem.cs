namespace TotemPWA.Models
{

    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public ICollection<Customize> Customizations { get; set; }
    }
}