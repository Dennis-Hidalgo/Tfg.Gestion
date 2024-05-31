using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Customers
{
    public class CustomerDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
