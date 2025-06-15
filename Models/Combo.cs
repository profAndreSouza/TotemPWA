namespace TotemPWA.Models
{

    public class Combo
    {
        public int Id { get; set; }

        public int ProductComboId { get; set; }
        public Product ProductCombo { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}