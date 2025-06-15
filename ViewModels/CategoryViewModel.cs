using Microsoft.AspNetCore.Mvc.Rendering;
using TotemPWA.Models;
using System.Collections.Generic;

namespace TotemPWA.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; } = new Category
        {
            Name = string.Empty,
            Icon = string.Empty,
        };
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
