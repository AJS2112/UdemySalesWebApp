using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UdemySalesWebApp.Models
{
    public class ReportViewModel
    {
        public int CodigoProduct { get; set; }
        public string Description { get; set; }
        public double TotalSale { get; set; }

        /*public List<ReportViewModel> List;

        protected ApplicationDbContext mContext;

        public ReportViewModel(ApplicationDbContext context)
        {
            mContext = context;

            var list = mContext.SaleProducts.GroupBy(x => x.CodigoProduct).ToList();
        }*/
    }
}
