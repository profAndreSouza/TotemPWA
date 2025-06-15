namespace TotemPWA.Models
{

    public class Cupom
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; } // percentual ou valor fixo
        public decimal Value { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}