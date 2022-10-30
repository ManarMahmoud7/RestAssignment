using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Text;

namespace BusinessLayer.Models.Business
{
    public class ProductUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public string CategoryId { get; set; }
    }
}
