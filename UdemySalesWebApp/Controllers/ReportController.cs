using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Models;

namespace UdemySalesWebApp.Controllers
{
    public class ReportController : Controller
    {
        //protected ApplicationDbContext mContext;
        readonly ISaleServiceApp SaleServiceApp;

        //public ReportController(ApplicationDbContext context)
        //{
        //    mContext = context;
        //}
        public ReportController(ISaleServiceApp saleServiceApp)
        {
            SaleServiceApp = saleServiceApp;
        }
        public IActionResult Graph()
        {
            var list = SaleServiceApp.GetProductsTotals().ToList();
            //var data = from sp in mContext.SaleProducts
            //           group sp by sp.CodigoProduct into SaleReport
            //           select new { 
            //               c = SaleReport.Key,
            //               t = SaleReport.Sum(x => x.Quantity),
            //           };
            //    var q = from sg in data
            //           join p in mContext.Product on sg.c equals p.Codigo
            //            select new ReportViewModel()
            //            {
            //                CodigoProduct = sg.c,
            //                Description = p.Description,
            //                TotalSale = sg.t
            //            };

            //var list = q.ToList();

            string values = string.Empty;
            string labels = string.Empty;
            string colors = string.Empty;
            
            var random = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                values += list[i].TotalSale.ToString() + ",";
                labels += "'" + list[i].Description.ToString() + "',";
                colors += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Values = values;
            ViewBag.Labels = labels;
            ViewBag.Colors = colors;

            return View(); 
        }
    }
}