using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Orders
{
    public class CustomerLookupDto : EntityDto<Guid>
    {
        public string FirstName { get; set; }
    }
}
