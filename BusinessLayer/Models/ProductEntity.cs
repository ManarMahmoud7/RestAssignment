using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;

namespace BusinessLayer.Models
{
    public class ProductEntity : BaseEntity
    {
        [Required]
        public double Price { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Url]
        public string ImageUrl { get; set; }

        public Guid CategoryEntityId { get; set; }
    }
}
