using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Entities;

namespace Domain.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        new IEnumerable<Product> GetAll();
    }
}
