using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemySalesWebApp.Models;

namespace Application.Services.Interfaces
{
    public interface IProductServiceApp
    {
        IEnumerable<SelectListItem> GetAllDropDownList();
        IEnumerable<ProductViewModel> GetAll();

        ProductViewModel GetOne(int id);

        void SetOne(ProductViewModel one);

        void DelOne(int id);
    }
}
