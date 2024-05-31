using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tfg.Gestion.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; } = string.Empty;

        public float Price { get; set; }
        [Required]
        [StringLength(128)]
        public string Description { get; set; } = string.Empty;

        public ProductCategory MyCategory { get; set; }

        public string Image {  get; set; }

        public int Stock { get; set; } = 50;

    }
}
