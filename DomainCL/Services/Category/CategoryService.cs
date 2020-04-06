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
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return CategoryRepository.GetAll();
        }

        public Entities.Category GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Entities.Category category)
        {
            throw new NotImplementedException();
        }
    }
}
