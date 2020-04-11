using System;
using System.Collections.Generic;
using System.Text;
using UdemySalesWebApp.Domain.DTO;

namespace Domain.Repository
{
    public interface ISaleProductsRepository
    {
        IEnumerable<ReportViewModel> GetProductsTotals();
    }
}
