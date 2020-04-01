using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Domain.Entities
{
    public class SaleProducts
    {
        public int CodigoSale { get; set; }
        public int CodigoProduct { get; set; }
        public double Quantity { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal Total { get; set; }

        public Sale Sale { get; set; }
        public Product Product { get; set; }


    }
}
