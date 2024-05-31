using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.Products
{
    public class Product : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public ProductCategory MyCategory { get; set; }

        public string Image { get; set; }
        public int Stock {  get; set; }
    }
}
