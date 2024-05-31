using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Invoices
{
    public class InvoiceDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string OrderName { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
