using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UdemySalesWebApp.Domain.DTO;
using UdemySalesWebApp.Domain.Entities;

namespace Repository.Entitites
{
    public class SaleProductsRepository : ISaleProductsRepository
    {
        protected ApplicationDbContext DbSetContext;

        public SaleProductsRepository(ApplicationDbContext mContext)
        {
            DbSetContext = mContext;
        }

        public IEnumerable<ReportViewModel> GetProductsTotals()
        {
            var data = from sp in DbSetContext.SaleProducts
                       group sp by sp.CodigoProduct into SaleReport
                       select new
                       {
                           c = SaleReport.Key,
                           t = SaleReport.Sum(x => x.Quantity),
                       };
            var q = from sg in data
                    join p in DbSetContext.Product on sg.c equals p.Codigo
                    select new ReportViewModel()
                    {
                        CodigoProduct = sg.c,
                        Description = p.Description,
                        TotalSale = sg.t
                    };

            var list = q.ToList();
            return list;
        }
    }
}
