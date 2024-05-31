using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.SalesHistories
{
    public class CreateUpdateSalesHistoryDto
    {
        public Guid OrderId { get; set; }
        public DateTime SaleDateTime { get; set; }
        public decimal TotalAmount { get; set; }
    }   
}
