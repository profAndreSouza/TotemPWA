namespace TotemPWA.Models
{

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }

        public Employee Employee { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}