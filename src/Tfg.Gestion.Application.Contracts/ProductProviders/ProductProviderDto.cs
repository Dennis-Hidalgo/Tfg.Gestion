using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.ProductProviders
{
    public class ProductProviderDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
