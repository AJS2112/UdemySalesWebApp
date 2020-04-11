using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.Domain.Entities;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Models;

namespace Application.Services
{
    public class ProductServiceApp :  IProductServiceApp
    {
        private readonly IProductService Service;

        public ProductServiceApp(IProductService service)
        {
            Service = service;
        }

        public void DelOne(int id)
        {
            Service.DelOne(id);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            List<ProductViewModel> listEntity = new List<ProductViewModel>();
            var list = Service.GetAll();
            foreach (var item in list)
            {
                ProductViewModel one = new ProductViewModel()
                {
                    Codigo = item.Codigo,
                    Description = item.Description,
                    CodigoCategory = item.CodigoCategory,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    CategoryDescription = item.Category.Description                    
                };

                listEntity.Add(one);

            }

            return listEntity;
        }

        public IEnumerable<SelectListItem> GetAllDropDownList()
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            var list = this.GetAll();
            foreach (var item in list)
            {
                SelectListItem one = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Description
                };

                listItem.Add(one);

            }

            return listItem;
        }

        public ProductViewModel GetOne(int id)
        {
            var record = Service.GetOne(id);

            ProductViewModel one = new ProductViewModel()
            {
                Codigo = record.Codigo,
                Description = record.Description,
                CodigoCategory = record.CodigoCategory,
                Price = record.Price,
                Quantity = record.Quantity
            };

            return one;
        }

        public void SetOne(ProductViewModel oneVM)
        {
            Product one = new Product()
            {
                Codigo = oneVM.Codigo,
                Description = oneVM.Description,
                CodigoCategory = (int) oneVM.CodigoCategory,
                Price = (decimal) oneVM.Price,
                Quantity = oneVM.Quantity
            };
            Service.SetOne(one);
        }
    }
}
