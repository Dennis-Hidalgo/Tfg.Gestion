using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.SalesHistories
{
    public class SalesHistoryDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public DateTime SaleDateTime { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
