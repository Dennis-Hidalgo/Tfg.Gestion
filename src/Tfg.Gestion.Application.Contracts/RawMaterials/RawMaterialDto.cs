using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.RawMaterials
{
    public class RawMaterialDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductProviderId { get; set; }

        public string ProductProviderName { get; set; }
    }
}
