using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.Orders
{
    public class CreateUpdateOrderDto
    {
        public Guid CustomerId { get; set; }
        public string OrderStatus { get; set; }

        public Guid UserId { get; set; }
    }
}
