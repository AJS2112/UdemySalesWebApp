using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UdemySalesWebApp.Domain.Entities;

namespace Repository.Entitites
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void DelOne(int id)
        {
            var productList = DbSetContext.Include(x => x.Products)
                .Where(y => y.Codigo == id)
                .AsNoTracking().ToList();

            foreach (var item in productList[0].Products)
            {
                SaleProducts saleProducts = new SaleProducts()
                {
                    CodigoSale = id,
                    CodigoProduct = item.CodigoProduct
                };
                 
                DbSet<SaleProducts> DbSetAux;

                DbSetAux = Db.Set<SaleProducts>();
                DbSetAux.Attach(saleProducts);
                DbSetAux.Remove(saleProducts);
                Db.SaveChanges();
            }


            base.DelOne(id);
        }

    }
}
