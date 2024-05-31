using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tfg.Gestion.Dishes
{
    public class Dish : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DishCategory Category { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
