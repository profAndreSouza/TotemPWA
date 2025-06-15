namespace TotemPWA.Models
{

    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string Type { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; }
    }

}