using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UdemySalesWebApp.Domain.Entities;

namespace Repository.Entitites
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        public override IEnumerable<Product> GetAll()
        {
            return DbSetContext.Include(x => x.Category).AsNoTracking().ToList();
        }
    }
}
