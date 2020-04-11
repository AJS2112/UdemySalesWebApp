using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UdemySalesWebApp.Models;

namespace UdemySalesWebApp.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductServiceApp ServiceApp;
        readonly ICategoryServiceApp CategoryServiceApp;

        public ProductController(
            IProductServiceApp serviceApp,
            ICategoryServiceApp categoryServiceApp)
        {
            ServiceApp = serviceApp;
            CategoryServiceApp = categoryServiceApp;
        }
        public IActionResult Index()
        {
            return View(ServiceApp.GetAll());
        }

        [HttpGet]
        public IActionResult Registry(int? id)
        {
            ProductViewModel viewModel = new ProductViewModel();
            if (id != null)
            {
                viewModel = ServiceApp.GetOne((int)id);
            }
            viewModel.CategoryList = CategoryServiceApp.GetAllDropDownList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registry(ProductViewModel entity)
        {
            if (ModelState.IsValid)
            {
                ServiceApp.SetOne(entity);
            }
            else
            {
                entity.CategoryList = CategoryServiceApp.GetAllDropDownList();
                return View(entity);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ServiceApp.DelOne(id);
            return RedirectToAction("Index");
        }
    }
}