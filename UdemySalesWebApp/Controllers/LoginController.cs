using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemySalesWebApp.Helpers;
using UdemySalesWebApp.Models;

namespace UdemySalesWebApp.Controllers
{
    public class LoginController : Controller
    {
        //protected ApplicationDbContext mContext;
        protected IHttpContextAccessor HttpContextAccessor;
        readonly IUserServiceApp ServiceApp;
        public LoginController(IUserServiceApp serviceApp, IHttpContextAccessor httpContextAccessor)
        {
            ServiceApp = serviceApp;
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index(int? logoff)
        {
            if (logoff != null)
            {
                if (logoff == 0)
                {
                    HttpContextAccessor.HttpContext.Session.Clear();
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErrorLogin"] = string.Empty;
            if (ModelState.IsValid)
            {

                var pass = Cryptography.GetMD5Hash( model.Password);
                bool login = ServiceApp.ValidateLogin(model.Email, pass);

                if (!login)
                {
                    ViewData["ErrorLogin"] = "User doesn't exist!!";
                    return View(model);
                } else
                {
                    var usuario = ServiceApp.GetUserData(model.Email, pass);
                    HttpContextAccessor.HttpContext.Session.SetString(Session.USER_NAME, usuario.Name);
                    HttpContextAccessor.HttpContext.Session.SetString(Session.USER_EMAIL, usuario.Email);
                    HttpContextAccessor.HttpContext.Session.SetInt32(Session.USER_CODIGO, (int)usuario.Codigo);
                    HttpContextAccessor.HttpContext.Session.SetInt32(Session.USER_LOGGED, 1);

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