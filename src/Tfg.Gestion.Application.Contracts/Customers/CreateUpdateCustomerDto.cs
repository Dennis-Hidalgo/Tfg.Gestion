using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.Customers
{
    public class CreateUpdateCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

}
