using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.RawMaterials;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.Inventories
{
    public class Inventory : FullAuditedEntity<Guid>
    {
        public Guid RawMaterialId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public int StockQuantity { get; set; }
        public DateTime LastRestockDate { get; set; }
    }
}
