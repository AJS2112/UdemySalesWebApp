using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UdemySalesWebApp.DAL;
using UdemySalesWebApp.Entities;
using UdemySalesWebApp.Models;

namespace UdemySalesWebApp.Controllers
{
    public class ProductController : Controller
    {
        protected ApplicationDbContext mContext;

        public ProductController(ApplicationDbContext context)
        {
            mContext = context;
        }

        private IEnumerable<SelectListItem> CategoryList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in mContext.Category.ToList())
            {
                list.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Description.ToString()
                });
            }

            return list;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> list = mContext.Product.Include(x => x.Category).ToList();
            mContext.Dispose();

            return View(list);
        }

        [HttpGet]
        public IActionResult Registry(int? id)
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.CategoryList = CategoryList(); 
            if (id != null)
            {
                var entity = mContext.Product.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entity.Codigo;
                viewModel.Description = entity.Description;
                viewModel.Quantity = entity.Quantity;
                viewModel.Price = entity.Price;
                viewModel.CodigoCategory = entity.CodigoCategory;

            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Registry(ProductViewModel entity)
        {
            if (ModelState.IsValid)
            {
                Product objProduct = new Product()
                {
                    Codigo = entity.Codigo,
                    Description = entity.Description,
                    Quantity = entity.Quantity,
                    Price = (decimal)entity.Price,
                    CodigoCategory = (int)entity.CodigoCategory
                };

                if (entity.Codigo == null)
                {
                    mContext.Product.Add(objProduct);
                } else
                {
                    mContext.Entry(objProduct).State = EntityState.Modified;
                }
                mContext.SaveChanges();
            }
            else
            {
                entity.CategoryList = CategoryList();
                return View(entity);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ent = new Product() { Codigo = id};
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}