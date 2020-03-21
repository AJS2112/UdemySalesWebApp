using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Models
{
    public class CategoryViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage ="The Category Description is Required!")]
        public string Description { get; set; }
    }
}
