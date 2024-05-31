using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public ProductCategory MyCategory { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; } = 50;
    }
}
