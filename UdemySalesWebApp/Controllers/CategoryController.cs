using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemySalesWebApp.DAL;
using UdemySalesWebApp.Entities;
using UdemySalesWebApp.Models;

namespace UdemySalesWebApp.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryServiceApp CategoryServiceApp;
        public CategoryController(ICategoryServiceApp categoryServiceApp, ApplicationDbContext context)
        {
            CategoryServiceApp = categoryServiceApp;
        }
        public IActionResult Index()
        {
            return View(CategoryServiceApp.GetAll());
        }

        [HttpGet]
        public IActionResult Registry(int? id)
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            if (id != null)
            {
                viewModel = CategoryServiceApp.GetOne((int)id);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registry(CategoryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                CategoryServiceApp.SetOne(entity);
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
            CategoryServiceApp.DelOne(id);
            return RedirectToAction("Index");
        }

    }
}