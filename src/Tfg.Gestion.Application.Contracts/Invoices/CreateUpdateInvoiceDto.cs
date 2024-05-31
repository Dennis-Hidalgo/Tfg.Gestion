using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.Invoices
{
    public class CreateUpdateInvoiceDto
    {
        public Guid OrderId { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
