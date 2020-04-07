using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Domain.Entities;
using Domain.Repository;

namespace UdemySalesWebApp.Domain.Services
{
    public class ClientService : IClientService
    {
        IClientRepository Repository;
        public ClientService(IClientRepository repository)
        {
            Repository = repository;
        }
        public void DelOne(int id)
        {
            Repository.DelOne(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return Repository.GetAll();
        }

        public Entities.Client GetOne(int id)
        {
            return Repository.GetOne(id);
        }

        public void SetOne(Entities.Client one)
        {
            Repository.SetOne(one);
        }
    }
}
