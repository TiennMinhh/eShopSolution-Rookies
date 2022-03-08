using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class City : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 250)]
        public string Name { get; set; }        
        public int Status { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
