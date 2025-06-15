using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TotemPWA.Models;

namespace TotemPWA.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        [ValidateNever]
        public List<SelectListItem> Categories { get; set; }
    }
}
