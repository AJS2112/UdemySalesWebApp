using Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.Domain.Entities;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Models;

namespace Application.Services
{
    public class ClientServiceApp :  IClientServiceApp
    {
        private readonly IClientService Service;

        public ClientServiceApp(IClientService service)
        {
            Service = service;
        }

        public void DelOne(int id)
        {
            Service.DelOne(id);
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            List<ClientViewModel> listEntity = new List<ClientViewModel>();
            var list = Service.GetAll();
            foreach (var item in list)
            {
                ClientViewModel one = new ClientViewModel()
                {
                    Codigo = item.Codigo,
                    Name = item.Name,
                    DocumentNumber = item.DocumentNumber,
                    Email = item.Email,
                    Phone = item.Phone
                };

                listEntity.Add(one);

            }

            return listEntity;
        }

        public ClientViewModel GetOne(int id)
        {
            var record = Service.GetOne(id);

            ClientViewModel one = new ClientViewModel()
            {
                Codigo = record.Codigo,
                Name = record.Name,
                DocumentNumber = record.DocumentNumber,
                Email = record.Email,
                Phone = record.Phone
            };

            return one;
        }

        public void SetOne(ClientViewModel oneVM)
        {
            Client one = new Client()
            {
                Codigo = oneVM.Codigo,
                Name = oneVM.Name,
                DocumentNumber = oneVM.DocumentNumber,
                Email = oneVM.Email,
                Phone = oneVM.Phone
            };
            Service.SetOne(one);
        }
    }
}
