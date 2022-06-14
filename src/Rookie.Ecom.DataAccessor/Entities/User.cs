using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 250)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Password { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Email { get; set; }
        public int Status { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductFeedBack> ProductFeedBacks { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
