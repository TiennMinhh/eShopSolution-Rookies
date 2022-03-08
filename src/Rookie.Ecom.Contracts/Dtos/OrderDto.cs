using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class OrderDto : BaseDto
    {
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public string AddressLine { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }

    }
}
