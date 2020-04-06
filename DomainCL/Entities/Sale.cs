using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Domain.Entities
{
    public class Sale : EntityBase
    {
        public DateTime Date { get; set; }
        
        [ForeignKey("Client")]
        public int CodigoClient { get; set; }
        public decimal Total { get; set; }

        public Client Client { get; set; }
        public ICollection<SaleProducts> Products { get; set; }

    }
}
