using Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
