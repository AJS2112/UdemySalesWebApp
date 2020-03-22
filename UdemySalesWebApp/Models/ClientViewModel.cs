using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Models
{
    public class ClientViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage ="The Client Name is Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Client Document Number is Required!")]
        public string DocumentNumber { get; set; }
        [Required(ErrorMessage = "The Client Email is Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Client Phone is Required!")]
        public string Phone { get; set; }
    }
}
