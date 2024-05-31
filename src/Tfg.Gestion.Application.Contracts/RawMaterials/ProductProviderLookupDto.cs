using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.RawMaterials
{
    public class ProductProviderLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
