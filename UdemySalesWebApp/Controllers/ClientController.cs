using System;
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
    public class ClientController : Controller
    {
        protected ApplicationDbContext mContext;

        public ClientController(ApplicationDbContext context)
        {
            mContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Client> list = mContext.Client.ToList();
            mContext.Dispose();

            return View(list);
        }

        [HttpGet]
        public IActionResult Registry(int? id)
        {
            ClientViewModel viewModel = new ClientViewModel();

            if (id != null)
            {
                var entity = mContext.Client.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entity.Codigo;
                viewModel.Name = entity.Name;
                viewModel.DocumentNumber = entity.DocumentNumber;
                viewModel.Email = entity.Email;
                viewModel.Phone = entity.Phone;

            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Registry(ClientViewModel entity)
        {
            if (ModelState.IsValid)
            {
                Client objClient = new Client()
                {
                    Codigo = entity.Codigo,
                    Name = entity.Name,
                    DocumentNumber = entity.DocumentNumber,
                    Email = entity.Email,
                    Phone = entity.Phone
                };

                if (entity.Codigo == null)
                {
                    mContext.Client.Add(objClient);
                } else
                {
                    mContext.Entry(objClient).State = EntityState.Modified;
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
            var ent = new Client() { Codigo = id};
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}