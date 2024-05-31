using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.RawMaterialDetails
{
    public class RawMaterialDetailDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid DishId { get; set; }
        public Guid RawMaterialId { get; set; }
        public int Quantity { get; set; }
    }
}
