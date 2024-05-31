using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.ProductProviders
{
    public class CreateUpdateProductProviderDto
    {
        public string Name { get; set; }    
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
