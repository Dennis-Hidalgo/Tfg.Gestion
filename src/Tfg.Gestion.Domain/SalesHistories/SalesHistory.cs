using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Orders;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.SalesHistories
{
    public class SalesHistory : FullAuditedEntity<Guid>
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime SaleDateTime { get; set; }
        public float TotalAmount { get; set; }
    }
}
