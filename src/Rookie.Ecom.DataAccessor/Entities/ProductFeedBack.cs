using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class ProductFeedBack : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
