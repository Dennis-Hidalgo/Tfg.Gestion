using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.RawMaterials
{
    public class CreateUpdateRawMaterialDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductProviderId { get; set; }
    }
}
