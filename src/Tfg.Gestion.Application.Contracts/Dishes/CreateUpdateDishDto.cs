using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tfg.Gestion.Dishes
{
    public class CreateUpdateDishDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime PublishDate { get; set; } = DateTime.Now;
        [Required]
        public DishCategory Category { get; set; }

    }
}
