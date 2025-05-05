namespace TotemPWA.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // 1-to-many self-referencing relationship for subcategories
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }  // Nullable, because a category may not have a parent category
        public ICollection<Category> Subcategories { get; set; } = new List<Category>();

        // 1-to-many relationship between Category and Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
