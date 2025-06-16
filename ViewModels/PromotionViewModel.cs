using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TotemPWA.ViewModels
{
    public class PromotionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "O produto é obrigatório.")]
        public int ProductId { get; set; }

        [Display(Name = "Desconto (%)")]
        [Range(0, 100, ErrorMessage = "O desconto deve estar entre 0 e 100.")]
        public decimal Percent { get; set; }

        [Display(Name = "Válido até")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de validade é obrigatória.")]
        public DateTime ValidUntil { get; set; }

        public List<SelectListItem> Products { get; set; } = new();
    }
}
