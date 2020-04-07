using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.Models;

namespace Application.Services.Interfaces
{
    public interface IClientServiceApp
    {
        IEnumerable<ClientViewModel> GetAll();

        ClientViewModel GetOne(int id);

        void SetOne(ClientViewModel one);

        void DelOne(int id);
    }
}
