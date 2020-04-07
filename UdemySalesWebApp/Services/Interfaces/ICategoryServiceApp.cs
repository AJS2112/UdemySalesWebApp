﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.Models;

namespace Application.Services.Interfaces
{
    public interface ICategoryServiceApp
    {
        IEnumerable<CategoryViewModel> GetAll();

        CategoryViewModel GetOne(int id);

        void SetOne(CategoryViewModel one);

        void DelOne(int id);
    }
}
