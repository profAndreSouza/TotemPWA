public class CategorySeed
{
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public List<CategorySeed>? Subcategories { get; set; }
    public List<ProductSeed>? Products { get; set; }
}

public class ProductSeed
{
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Price { get; set; } 
}

