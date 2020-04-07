using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Models
{
    public class ProductViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage ="The Product Description is Required!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Product Quantity in Stock is Required!")]
        public double Quantity { get; set; }
        [Required(ErrorMessage = "The Product Price is Required!")]
        [Range(0.1,Double.PositiveInfinity)]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "The Product Category is Required!")]
        public int? CodigoCategory { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public string CategoryDescription { get; set; }

    }
}
