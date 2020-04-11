using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Domain.Entities;
using Domain.Repository;
using Domain.Interfaces;

namespace UdemySalesWebApp.Domain.Services
{
    public class UserService : IUserService
    {
        IUserRepository Repository;
        public UserService(IUserRepository repository)
        {
            Repository = repository;
        }
        public void DelOne(int id)
        {
            Repository.DelOne(id);
        }

        public IEnumerable<User> GetAll()
        {
            return Repository.GetAll();
        }

        public Entities.User GetOne(int id)
        {
            return Repository.GetOne(id);
        }

        public void SetOne(Entities.User one)
        {
            Repository.SetOne(one);
        }

        public bool ValidateLogin(string email, string password)
        {
            return Repository.ValidateLogin(email, password);
        }
    }
}
