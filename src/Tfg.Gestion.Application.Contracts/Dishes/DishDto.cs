using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tfg.Gestion.Dishes
{
    public class DishDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public DateTime PublishDate { get; set; }
        public DishCategory Category { get; set; }

    }
}
