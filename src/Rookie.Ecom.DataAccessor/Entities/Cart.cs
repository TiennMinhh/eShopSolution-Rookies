using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Cart : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Photo { get; set; }
    }
}
