using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UdemySalesWebApp.DAL;
using UdemySalesWebApp.Entities;
using UdemySalesWebApp.Models;

namespace UdemySalesWebApp.Controllers
{
    public class SaleController : Controller
    {
        protected ApplicationDbContext mContext;

        public SaleController(ApplicationDbContext context)
        {
            mContext = context;
        }

        private IEnumerable<SelectListItem> ClientList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in mContext.Client.ToList())
            {
                list.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Name.ToString()
                });
            }

            return list;
        }

        private IEnumerable<SelectListItem> ProductList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in mContext.Product.ToList())
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
            IEnumerable<Sale> list = mContext.Sale.ToList();
            mContext.Dispose();

            return View(list);
        }

        [HttpGet]
        public IActionResult Registry(int? id)
        {
            SaleViewModel viewModel = new SaleViewModel();
            viewModel.ClientList = ClientList();
            viewModel.ProductList = ProductList();

            if (id != null)
            {
                var entity = mContext.Sale.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entity.Codigo;
                viewModel.Date = entity.Date;
                viewModel.CodigoClient = entity.CodigoClient;
                viewModel.Total = entity.Total;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Registry(SaleViewModel entity)
        {
            if (ModelState.IsValid)
            {
                Sale objSale = new Sale()
                {
                    Codigo = entity.Codigo,
                    Date = (DateTime)entity.Date,
                    CodigoClient = (int)entity.CodigoClient,
                    Total = (decimal)entity.Total,
                    Products = JsonConvert.DeserializeObject<ICollection<SaleProducts>>(entity.JsonProducts)
                };

                if (entity.Codigo == null)
                {
                    mContext.Sale.Add(objSale);
                }
                else
                {
                    mContext.Entry(objSale).State = EntityState.Modified;
                }
                mContext.SaveChanges();
            }
            else
            {
                entity.ClientList = ClientList();
                entity.ProductList = ProductList();

                return View(entity);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ent = new Sale() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("ReadProductPrice/{CodigoProduct}")]
        public decimal ReadProductPrice(int CodigoProduct)
        {
            return mContext.Product.Where(x => x.Codigo == CodigoProduct)
                                    .Select(x => x.Price)
                                    .FirstOrDefault();
        }
    }
}