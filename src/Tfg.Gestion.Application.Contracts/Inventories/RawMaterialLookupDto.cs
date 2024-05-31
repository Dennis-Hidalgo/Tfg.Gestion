using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Inventories
{
    public class RawMaterialLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
