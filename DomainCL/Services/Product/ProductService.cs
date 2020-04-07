using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Domain.Entities;
using Domain.Repository;

namespace UdemySalesWebApp.Domain.Services
{
    public class ProductService : IProductService
    {
        IProductRepository Repository;
        public ProductService(IProductRepository repository)
        {
            Repository = repository;
        }
        public void DelOne(int id)
        {
            Repository.DelOne(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return Repository.GetAll();
        }

        public Entities.Product GetOne(int id)
        {
            return Repository.GetOne(id);
        }

        public void SetOne(Entities.Product one)
        {
            Repository.SetOne(one);
        }
    }
}
