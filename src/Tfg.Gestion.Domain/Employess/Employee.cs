using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.Employess
{
    public class Employee : FullAuditedEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Dni { get; set; }
        public DateTime HireDate { get; set; }
    }
}
