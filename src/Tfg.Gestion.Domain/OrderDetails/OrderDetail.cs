using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Dishes;
using Tfg.Gestion.Orders;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.OrderDetails
{
    public class OrderDetail : FullAuditedEntity<Guid>
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid DishId { get; set; }
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
