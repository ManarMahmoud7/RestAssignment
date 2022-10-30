using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public  class CategoryEntity :BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public override string Name { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
    }
}
