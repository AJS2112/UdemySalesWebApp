using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Models
{
    public class SaleViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage ="The Sale Date is Required!")]
        public DateTime Date { get; set; }  
        [Required(ErrorMessage = "The Sale Client is Required!")]
        public int CodigoClient { get; set; }

        public decimal Total { get; set; }
        public IEnumerable<SelectListItem> ClientList { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }


        public string JsonProducts { get; set; }

    }
}
