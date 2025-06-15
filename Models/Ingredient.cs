namespace TotemPWA.Models
{

    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Limit { get; set; }

        public ICollection<Additional> Additionals { get; set; }
        public ICollection<Customize> Customizations { get; set; }
    }
}