using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Entities;

namespace UdemySalesWebApp.Domain.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetOne(int id);
        void Save(Category category);
        void Delete(int id);
    }
}
