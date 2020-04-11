using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Domain.Entities;
using Domain.Repository;
using UdemySalesWebApp.Domain.DTO;

namespace UdemySalesWebApp.Domain.Services
{
    public class SaleService : ISaleService
    {
        ISaleRepository Repository;
        ISaleProductsRepository SaleProductsRepository;
        public SaleService(ISaleRepository repository, ISaleProductsRepository saleProductsRepository)
        {
            Repository = repository;
            SaleProductsRepository = saleProductsRepository;
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

        public IEnumerable<ReportViewModel> GetProductsTotals()
        {
            return SaleProductsRepository.GetProductsTotals();
        }

        public void SetOne(Entities.Sale one)
        {
            Repository.SetOne(one);
        }
    }
}
