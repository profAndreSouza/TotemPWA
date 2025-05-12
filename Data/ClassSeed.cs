public class CategorySeed
{
    public string Name { get; set; } = string.Empty;
    public List<CategorySeed>? Subcategories { get; set; }
    public List<ProductSeed>? Products { get; set; }
}

public class ProductSeed
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } 
    public List<VariationSeed>? Variations { get; set; }
}

public class VariationSeed
{
    public string Description { get; set; } = string.Empty; 
    public decimal AdditionalPrice { get; set; } 
}
