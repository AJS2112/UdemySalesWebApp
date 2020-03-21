using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UdemySalesWebApp.DAL;
using UdemySalesWebApp.Entities;
using UdemySalesWebApp.Models;

namespace UdemySalesWebApp.Controllers
{
    public class HomeController : Controller
    {
        protected ApplicationDbContext Repository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext repository)
        {
            Repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //UPDATE
            Category objCategory = Repository.Category.Where(x => x.Codigo == 1).FirstOrDefault();
            objCategory.Description = "Drinks";
            Repository.Entry(objCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //DELETE
            Category objCategoryDel = Repository.Category.Where(x => x.Codigo == 2).FirstOrDefault();
            Repository.Attach(objCategoryDel);
            Repository.Remove(objCategoryDel);

            Repository.SaveChanges();

            IEnumerable<Category> list = Repository.Category.ToList();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
