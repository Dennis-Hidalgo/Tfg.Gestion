using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Dishes;
using Tfg.Gestion.RawMaterials;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.RawMaterialDetails
{
    public class RawMaterialDetail : FullAuditedEntity<Guid>
    {
        public Guid DishId { get; set; }
        public Dish Dish { get; set; }
        public Guid RawMaterialId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public int Quantity { get; set; }
    }
}
