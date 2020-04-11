using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.Domain.Entities;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Models;

namespace Application.Services
{
    public class UserServiceApp : IUserServiceApp
    {
        private readonly IUserService Service;

        public UserServiceApp(IUserService service)
        {
            Service = service;
        }

        public User GetUserData(string email, string password)
        {
            return Service.GetAll().Where(x => x.Email == email && x.Password.ToLower() == password.ToLower()).FirstOrDefault();
        }

        public bool ValidateLogin(string email, string password)
        {
            return Service.ValidateLogin(email, password);
        }
    }
}
