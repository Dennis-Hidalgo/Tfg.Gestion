    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Customers;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.Orders
{
    public class Order : FullAuditedEntity<Guid>
    {
        public DateTime OrderDateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string OrderStatus { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }
    }
}
