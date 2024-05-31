using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Inventories
{
    public class InventoryDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid RawMaterialId { get; set; }
        public string RawMaterialName { get; set; }
        public int StockQuantity { get; set; }
    }
}
