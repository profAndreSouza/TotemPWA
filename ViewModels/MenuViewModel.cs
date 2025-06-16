namespace TotemPWA.ViewModels
{
    public class MenuViewModel
    {
        public string? SelectedCategorySlug { get; set; }
        public string? SelectedSubcategorySlug { get; set; }

        public List<CategoryItemViewModel> RootCategories { get; set; } = new();
        public List<CategoryItemViewModel> Subcategories { get; set; } = new();
        public List<ProductItemViewModel> Products { get; set; } = new();
    }
}
