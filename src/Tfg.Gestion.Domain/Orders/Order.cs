    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Customers;
using Tfg.Gestion.Employess;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.Orders
{
    public class Order : FullAuditedEntity<Guid>
    {
        public DateTime OrderDateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string OrderStatus { get; set; }
    }
}
