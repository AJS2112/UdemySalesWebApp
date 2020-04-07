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
    public class ClientController : Controller
    {
        readonly IClientServiceApp ServiceApp;
        public ClientController(IClientServiceApp serviceApp, ApplicationDbContext context)
        {
            ServiceApp = serviceApp;
        }
        public IActionResult Index()
        {
            return View(ServiceApp.GetAll());
        }

        [HttpGet]
        public IActionResult Registry(int? id)
        {
            ClientViewModel viewModel = new ClientViewModel();
            if (id != null)
            {
                viewModel = ServiceApp.GetOne((int)id);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registry(ClientViewModel entity)
        {
            if (ModelState.IsValid)
            {
                ServiceApp.SetOne(entity);
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
            ServiceApp.DelOne(id);
            return RedirectToAction("Index");
        }
    }
}