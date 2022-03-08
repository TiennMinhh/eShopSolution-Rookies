using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
