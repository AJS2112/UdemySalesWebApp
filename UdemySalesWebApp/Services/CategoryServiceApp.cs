using Application.Services.Interfaces;
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
        private readonly ICategoryService CategoryService;

        public CategoryServiceApp(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        public void DelOne(int id)
        {
            CategoryService.DelOne(id);
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            List<CategoryViewModel> listCategory = new List<CategoryViewModel>();
            var list = CategoryService.GetAll();
            foreach (var item in list)
            {
                CategoryViewModel category = new CategoryViewModel()
                {
                    Codigo = item.Codigo,
                    Description = item.Description
                };

                listCategory.Add(category);

            }

            return listCategory;
        }

        public CategoryViewModel GetOne(int id)
        {
            var record = CategoryService.GetOne(id);

            CategoryViewModel category = new CategoryViewModel()
            {
                Codigo = record.Codigo,
                Description = record.Description
            };

            return category;
        }

        public void SetOne(CategoryViewModel categoryVM)
        {
            Category category = new Category()
            {
                Codigo = categoryVM.Codigo,
                Description = categoryVM.Description
            };
            CategoryService.SetOne(category);
        }
    }
}
