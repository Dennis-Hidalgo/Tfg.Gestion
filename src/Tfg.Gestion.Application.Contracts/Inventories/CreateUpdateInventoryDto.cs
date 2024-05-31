using System;
using System.Collections.Generic;
using System.Text;

namespace Tfg.Gestion.Inventories
{
    public class CreateUpdateInventoryDto
    {
        public Guid RawMaterialId { get; set; }
        public int StockQuantity { get; set; }
    }
}
