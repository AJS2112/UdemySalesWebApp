using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Domain.Entities;
using Domain.Repository;

namespace UdemySalesWebApp.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository CategoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        public void DelOne(int id)
        {
            CategoryRepository.DelOne(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return CategoryRepository.GetAll();
        }

        public Entities.Category GetOne(int id)
        {
            return CategoryRepository.GetOne(id);
        }

        public void SetOne(Entities.Category category)
        {
            CategoryRepository.SetOne(category);
        }
    }
}
