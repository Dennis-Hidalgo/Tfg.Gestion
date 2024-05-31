using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Employess
{
    public class EmployeeDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Dni { get; set; }
        public DateTime HireDate { get; set; }
    }
}
