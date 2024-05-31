using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Orders;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.Invoices
{
    public class Invoice : FullAuditedEntity<Guid>
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime IssueDate { get; set; }
        public float TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
