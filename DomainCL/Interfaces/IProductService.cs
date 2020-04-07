using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Entities;

namespace UdemySalesWebApp.Domain.Interfaces
{
    public interface IProductService : ICRUDService<Product>
    {
        
    }
}
