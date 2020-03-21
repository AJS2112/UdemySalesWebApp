using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemySalesWebApp.Entities
{
    public class Client
    {
        [Key]
        public int? Codigo { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<Sale> Sales { get; set; }

    }
}
