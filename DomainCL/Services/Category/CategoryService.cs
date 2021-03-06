﻿using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Domain.Entities;
using Domain.Repository;

namespace UdemySalesWebApp.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository Repository;
        public CategoryService(ICategoryRepository repository)
        {
            Repository = repository;
        }
        public void DelOne(int id)
        {
            Repository.DelOne(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return Repository.GetAll();
        }

        public Entities.Category GetOne(int id)
        {
            return Repository.GetOne(id);
        }

        public void SetOne(Entities.Category one)
        {
            Repository.SetOne(one);
        }
    }
}
