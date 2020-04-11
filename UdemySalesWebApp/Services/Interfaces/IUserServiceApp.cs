using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.Domain.Entities;
using UdemySalesWebApp.Models;

namespace Application.Services.Interfaces
{
    public interface IUserServiceApp
    {
        bool ValidateLogin(string email, string password);

        User GetUserData(string email, string password);
    }
}
