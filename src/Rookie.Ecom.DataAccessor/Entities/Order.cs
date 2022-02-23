using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string AddressLine { get; set; }
        public int Phone { get; set; }
        public int Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
