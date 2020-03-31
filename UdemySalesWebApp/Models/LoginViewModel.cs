using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Email is Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password is Required!")]
        public string Password { get; set; }
    }
}
