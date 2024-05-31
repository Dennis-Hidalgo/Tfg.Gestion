using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.RawMaterialDetails
{
    public class CreateUpdateRawMaterialDetailDto
    {
        public Guid DishId { get; set; }
        public Guid RawMaterialId { get; set; }
        public int Quantity { get; set; }
    }
}
