using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.Entities;

namespace Domain.Repository
{
    public interface ISaleRepository : IRepository<Sale>
    {
        new void DelOne(int id);
    }
}
