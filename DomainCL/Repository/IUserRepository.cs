using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Entities;

namespace Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        bool ValidateLogin(string email, string password);
    }
}
