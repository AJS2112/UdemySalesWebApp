using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UdemySalesWebApp.Domain.Entities;

namespace Repository.Entitites
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public bool ValidateLogin(string email, string password)
        {
            var usuario = DbSetContext.Where(x => x.Email == email && x.Password.ToLower() == password.ToLower()).FirstOrDefault();
            return (usuario == null) ? false : true; 
        }
    }
}
