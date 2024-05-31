using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.ProductProviders;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.RawMaterials
{
    public class RawMaterial : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float PricePerUnit { get; set; }
        public int StockQuantity { get; set; }
        public Guid ProductProviderId { get; set; }
        public ProductProvider ProductProvider { get; set; }
    }
}
