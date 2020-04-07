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
    public class CategoryServiceApp : ICategoryServiceApp
    {
        private readonly ICategoryService Service;

        public CategoryServiceApp(ICategoryService service)
        {
            Service = service;
        }

        public void DelOne(int id)
        {
            Service.DelOne(id);
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            List<CategoryViewModel> listEntity = new List<CategoryViewModel>();
            var list = Service.GetAll();
            foreach (var item in list)
            {
                CategoryViewModel one = new CategoryViewModel()
                {
                    Codigo = item.Codigo,
                    Description = item.Description
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

        public CategoryViewModel GetOne(int id)
        {
            var record = Service.GetOne(id);

            CategoryViewModel one = new CategoryViewModel()
            {
                Codigo = record.Codigo,
                Description = record.Description
            };

            return one;
        }

        public void SetOne(CategoryViewModel oneVM)
        {
            Category one = new Category()
            {
                Codigo = oneVM.Codigo,
                Description = oneVM.Description
            };
            Service.SetOne(one);
        }
    }
}
