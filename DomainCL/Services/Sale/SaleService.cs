using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Domain.Entities;
using Domain.Repository;

namespace UdemySalesWebApp.Domain.Services
{
    public class SaleService : ISaleService
    {
        ISaleRepository Repository;
        public SaleService(ISaleRepository repository)
        {
            Repository = repository;
        }
        public void DelOne(int id)
        {
            Repository.DelOne(id);
        }

        public IEnumerable<Sale> GetAll()
        {
            return Repository.GetAll();
        }

        public Entities.Sale GetOne(int id)
        {
            return Repository.GetOne(id);
        }

        public void SetOne(Entities.Sale one)
        {
            Repository.SetOne(one);
        }
    }
}
