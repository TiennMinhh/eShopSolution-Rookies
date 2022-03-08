using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public int SortOrder { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Desc { get; set; }

        [StringLength(maximumLength: 250)]
        public Guid? ParentId { get; set; }

        public int Status { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
