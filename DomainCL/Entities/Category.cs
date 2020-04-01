using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Domain.Entities
{
    public class Category
    {
        [Key]
        public int? Codigo { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
