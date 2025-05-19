using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace TotemPWA.Models
{
    public class Category
    {
        public int Id { get; set; }

        private string _name;
        private string _slug;

        public required string Name
        {
            get => _name;
            set
            {
                _name = value;
                _slug = GenerateSlug(value);
            }
        }

        public string Slug => _slug;

        private string GenerateSlug(string text)
        {
            text = text.ToLowerInvariant().Trim();
            text = Regex.Replace(text, @"[^a-z0-9\s-]", "");
            text = Regex.Replace(text, @"\s+", "-");
            text = Regex.Replace(text, @"-+", "-");
            return text;
        }

        public required string Icon { get; set; }
        public int? ParentCategoryId { get; set; }

        [JsonIgnore]
        public Category? ParentCategory { get; set; }

        public ICollection<Category> Subcategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
