using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.OrderDetails
{
    public class OrderDetailDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid DishId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
