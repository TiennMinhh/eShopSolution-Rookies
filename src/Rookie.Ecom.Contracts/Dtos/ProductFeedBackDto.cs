using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductFeedBackDto : BaseDto
    {
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
