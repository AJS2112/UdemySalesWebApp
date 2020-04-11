using System;
using System.Collections.Generic;
using System.Text;

namespace UdemySalesWebApp.Domain.DTO
{
    public class ReportViewModel
    {
        public int CodigoProduct { get; set; }
        public string Description { get; set; }
        public double TotalSale { get; set; }
    }
}
