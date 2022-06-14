using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Desc { get; set; }

        public string Detail { get; set; }

        public decimal Price { get; set; }

        public decimal? Cost { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsHome { get; set; }

        public int Quantity { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductPicture> ProductPictures { get; set; }
    }
}