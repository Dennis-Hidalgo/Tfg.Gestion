using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Orders
{
    public class OrderDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string OrderStatus { get; set; }
        public string UserName { get; set; }

        public int PedidoId { get; set; }
    }
}
