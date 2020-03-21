﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemySalesWebApp.DAL;
using UdemySalesWebApp.Entities;
using UdemySalesWebApp.Models;

namespace UdemySalesWebApp.Controllers
{
    public class CategoryController : Controller
    {
        protected ApplicationDbContext mContext;

        public CategoryController(ApplicationDbContext context)
        {
            mContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> list = mContext.Category.ToList();
            mContext.Dispose();

            return View(list);
        }

        [HttpGet]
        public IActionResult Registry(int? id)
        {
            CategoryViewModel viewModel = new CategoryViewModel();

            if (id != null)
            {
                var entity = mContext.Category.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entity.Codigo;
                viewModel.Description = entity.Description;

            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Registry(CategoryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                Category objCategory = new Category()
                {
                    Codigo = entity.Codigo,
                    Description = entity.Description
                };

                if (entity.Codigo == null)
                {
                    mContext.Category.Add(objCategory);
                } else
                {
                    mContext.Entry(objCategory).State = EntityState.Modified;
                }
                mContext.SaveChanges();
            }
            else
            {
                return View(entity);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ent = new Category() { Codigo = id};
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}