using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.Employess
{
    public class CreateUpdateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Dni { get; set; }
        public DateTime HireDate { get; set; }
    }
}
