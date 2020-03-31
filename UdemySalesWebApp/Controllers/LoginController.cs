using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemySalesWebApp.DAL;
using UdemySalesWebApp.Helpers;
using UdemySalesWebApp.Models;

namespace UdemySalesWebApp.Controllers
{
    public class LoginController : Controller
    {
        protected ApplicationDbContext mContext;
        
        public LoginController(ApplicationDbContext context)
        {
            mContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErrorLogin"] = string.Empty;
            if (ModelState.IsValid)
            {

                var pass = Cryptography.GetMD5Hash( model.Password);
                var usuario = mContext.Users.Where(x => x.Email == model.Email && x.Password == pass).FirstOrDefault();
                if (usuario == null)
                {
                    ViewData["ErrorLogin"] = "User doesn't exist!!";
                    return View(model);
                } else
                {
                    ViewData["ErrorLogin"] = "";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}