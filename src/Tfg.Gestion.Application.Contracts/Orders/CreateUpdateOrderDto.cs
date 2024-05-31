using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.Orders
{
    public class CreateUpdateOrderDto
    {
        public DateTime OrderDateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public string OrderStatus { get; set; }
    }
}
