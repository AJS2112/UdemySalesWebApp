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
    public class SaleController : Controller
    {
        readonly ISaleServiceApp ServiceApp;
        readonly IProductServiceApp ProductServiceApp;
        readonly IClientServiceApp ClientServiceApp;


        public SaleController(
            ISaleServiceApp serviceApp,
            IProductServiceApp productServiceApp,
            IClientServiceApp clientServiceApp)
        {
            ServiceApp = serviceApp;
            ProductServiceApp = productServiceApp;
            ClientServiceApp = clientServiceApp;
        }
        public IActionResult Index()
        {
            return View(ServiceApp.GetAll());
        }
        [HttpGet]
        public IActionResult Registry(int? id)
        {
            SaleViewModel viewModel = new SaleViewModel();
            if (id != null)
            {
                viewModel = ServiceApp.GetOne((int)id);
            }

            viewModel.ClientList = ClientServiceApp.GetAllDropDownList();
            viewModel.ProductList = ProductServiceApp.GetAllDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registry(SaleViewModel entity)
        {
            if (ModelState.IsValid)
            {
                ServiceApp.SetOne(entity);
            }
            else
            {
                entity.ClientList = ClientServiceApp.GetAllDropDownList();
                entity.ProductList = ProductServiceApp.GetAllDropDownList();

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

        [HttpGet("ReadProductPrice/{CodigoProduct}")]
        public decimal ReadProductPrice(int codigoProduct)
        {
            return (decimal)ProductServiceApp.GetOne(codigoProduct).Price;
        }
    }
}