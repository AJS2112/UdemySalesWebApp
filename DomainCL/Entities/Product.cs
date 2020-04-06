using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Description { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public int CodigoCategory { get; set; }
        public Category Category { get; set; }
        public ICollection<SaleProducts> Sale { get; set; }

    }
}
