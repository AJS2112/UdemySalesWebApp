using Application.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.Domain.Entities;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Domain.Services;
using UdemySalesWebApp.Models;

namespace Application.Services
{
    public class SaleServiceApp :  ISaleServiceApp
    {
        private readonly ISaleService Service;

        public SaleServiceApp(ISaleService service)
        {
            Service = service;
        }

        public void DelOne(int id)
        {
            Service.DelOne(id);
        }

        public IEnumerable<SaleViewModel> GetAll()
        {
            List<SaleViewModel> listEntity = new List<SaleViewModel>();
            var list = Service.GetAll();
            foreach (var item in list)
            {
                SaleViewModel one = new SaleViewModel()
                {
                    Codigo = item.Codigo,
                    Date = item.Date,
                    CodigoClient = item.CodigoClient,
                    Total = item.Total
                };

                listEntity.Add(one);

            }

            return listEntity;
        }

        public SaleViewModel GetOne(int id)
        {
            var record = Service.GetOne(id);

            SaleViewModel one = new SaleViewModel()
            {
                Codigo = record.Codigo,
                Date = record.Date,
                CodigoClient = record.CodigoClient,
                Total = record.Total,
            };

            return one;
        }

        public IEnumerable<ReportViewModel> GetProductsTotals()
        {
            List<ReportViewModel> list = new List<ReportViewModel>();
            var auxList = Service.GetProductsTotals();
            foreach (var item in auxList)
            {
                ReportViewModel vm = new ReportViewModel()
                {
                    CodigoProduct = item.CodigoProduct,
                    Description = item.Description,
                    TotalSale = item.TotalSale
                };
                list.Add(vm);
            }
            return list;
        }

        public void SetOne(SaleViewModel oneVM)
        {
            Sale one = new Sale()
            {
                Codigo = oneVM.Codigo,
                Date = oneVM.Date,
                CodigoClient = oneVM.CodigoClient,
                Total = oneVM.Total,
                Products = JsonConvert.DeserializeObject<ICollection<SaleProducts>>(oneVM.JsonProducts)
            };
            Service.SetOne(one);
        }
    }
}
