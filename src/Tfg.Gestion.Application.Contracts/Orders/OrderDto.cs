using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Orders
{
    public class OrderDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public string OrderStatus { get; set; }
    }
}
