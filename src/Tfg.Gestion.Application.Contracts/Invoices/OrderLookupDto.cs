using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Invoices
{
    public class OrderLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
    
}
