using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.OrderDetails
{
    public class CreateUpdateOrderDetailDto
    {
        public Guid OrderId { get; set; }
        public Guid DishId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
