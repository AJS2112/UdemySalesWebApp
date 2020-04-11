using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.Models;

namespace Application.Services.Interfaces
{
    public interface ISaleServiceApp
    {
        IEnumerable<SaleViewModel> GetAll();

        SaleViewModel GetOne(int id);

        void SetOne(SaleViewModel one);

        void DelOne(int id);
    }
}
